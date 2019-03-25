using UnityEngine;
using UnityEditor;
using TheLiquidFire.AspectContainer;
using TheLiquidFire.Notifications;

public class MatchSystem : Aspect, IObserve
{
    public void ChangeTurn()
    {
        var match = container.GetMatch();
        var nextIndex = (1 - match.currentPlayerIndex);
        ChangeTurn(nextIndex);
    }

    public void ChangeTurn(int index)
    {
        var action = new ChangeTurnAction(index);
        Debug.Log("Change turn action intiated : " + action.ToString());
        container.Perform(action);
    }

    public void Awake()
    {
        this.AddObserver(OnPerformChangeTurn, Global.PerformNotification<ChangeTurnAction>(), container);
    }

    public void Destroy()
    {
        this.RemoveObserver(OnPerformChangeTurn, Global.PerformNotification<ChangeTurnAction>(), container);
    }

    public void OnPerformChangeTurn(object sender, object args)
    {
        var action = args as ChangeTurnAction;
        var match = container.GetMatch();
        match.currentPlayerIndex = action.targetPlayerIndex;
        Debug.Log("Turn changed. Active player : " + match.currentPlayerIndex);
    }
}