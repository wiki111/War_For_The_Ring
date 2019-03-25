using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheLiquidFire.AspectContainer;
using TheLiquidFire.Notifications;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChangeTurnView : MonoBehaviour, IPointerClickHandler {

    public GameObject infoView;
    IContainer game;

    public void OnPointerClick(PointerEventData eventData)
    {
        ChangeTurnButtonPressed();
    }

    public void ChangeTurnButtonPressed()
    {
        if (CanChangeTurn())
        {
            var system = game.GetAspect<MatchSystem>();
            system.ChangeTurn();
            Debug.Log("Change turn initiated");
        }
    }

    bool CanChangeTurn()
    {
        var stateMachine = game.GetAspect<StateMachine>();
        if (!(stateMachine.currentState is PlayerIdleState))
            return false;
        var player = game.GetMatch().GetCurrentPlayer();
        if (player.controlMode != ControlModes.User)
            return false;
        return true;
    }

    private void Awake()
    {
        game = GetComponentInParent<GameViewSystem>().container;
    }

    private void OnEnable()
    {
        this.AddObserver(OnPrepareChangeTurn, Global.PrepareNotification<ChangeTurnAction>(), game);
    }

    private void OnDisable()
    {
        this.RemoveObserver(OnPrepareChangeTurn, Global.PrepareNotification<ChangeTurnAction>(), game);
    }

    void OnPrepareChangeTurn(object sender, object args)
    {
        var action = args as ChangeTurnAction;
        action.after.viewer = ChangeTurnViewer;
    }

    IEnumerator ChangeTurnViewer(IContainer game, Action action)
    {
        var dataSystem = game.GetAspect<DataSystem>();
        var changeTurnAction = action as ChangeTurnAction;
        var targetPlayer = dataSystem.match.players[changeTurnAction.targetPlayerIndex];

        StartCoroutine("ShowInfo");
        yield return true;
    }

    IEnumerator ShowInfo()
    {
        infoView.GetComponentInChildren<Text>().text = "Your turn";
        infoView.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        infoView.SetActive(false);
    }
    
}

