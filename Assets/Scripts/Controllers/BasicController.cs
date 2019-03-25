using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheLiquidFire.AspectContainer;
using TheLiquidFire.Notifications;

public class BasicController : MonoBehaviour {

    IContainer game;
    Container container;
    //This will handle CONTROLLER STATES
    StateMachine stateMachine;

    //This is handle to currently active card
    CardView activeCardView;

    void Awake()
    {
        //get a handle to the main game container
        game = GetComponentInParent<GameViewSystem>().container;
        container = new Container();
        //This CREATES and adds a new StateMachine instance to the container
        stateMachine = container.AddAspect<StateMachine>();
        container.AddAspect(new IdleState()).owner = this;
        container.AddAspect(new CardChosenState()).owner = this;

        stateMachine.ChangeState<IdleState>();
    }

    private void OnEnable()
    {
        this.AddObserver(OnClickNotification, Clickable.ClickedNotification);
    }

    private void OnDisable()
    {
        this.RemoveObserver(OnClickNotification, Clickable.ClickedNotification);
    }

    void OnClickNotification(object sender, object args)
    {
        var handler = stateMachine.currentState as IInputHandler;
        if(handler != null)
        {
            handler.OnClickNotification(sender, args);
        }
    }

    private interface IInputHandler
    {
        void OnClickNotification(object sender, object args);
    }

    private abstract class BaseControllerState : BaseState
    {
        public BasicController owner;
    }

    private class IdleState : BaseControllerState, IInputHandler
    {
        public override void Enter()
        {
            base.Enter();
            if(owner.activeCardView != null)
            {
                owner.activeCardView.transform.localScale = Vector3.one;
                owner.activeCardView = null;
            }
        }

        public void OnClickNotification(object sender, object args)
        {
            //check state of the game here, and decide wheather to handle the event at this time or wait for change of game state
            var clickable = sender as Clickable;
            var cardView = clickable.GetComponent<CardView>();
            if (cardView == null || cardView.card.zone != Zones.Hand || cardView.card.ownerIndex != owner.game.GetMatch().currentPlayerIndex)
                return;
            owner.activeCardView = cardView;
            owner.stateMachine.ChangeState<CardChosenState>();
        }
    }

    private class CardChosenState : BaseControllerState, IInputHandler
    {
        public override void Enter()
        {
            base.Enter();
            owner.activeCardView.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        }

        public void OnClickNotification(object sender, object args)
        {
            var clickable = sender as Clickable;
            var playerTableView = clickable.GetComponent<PlayerTableView>();
            if (playerTableView != null && playerTableView.ownerIndex == owner.game.GetMatch().currentPlayerIndex)
            {
                owner.activeCardView.transform.localScale = new Vector3(1, 1, 1);
                owner.activeCardView.transform.parent = playerTableView.transform;
                owner.activeCardView = null;
            }

            owner.stateMachine.ChangeState<IdleState>();
                
        }
    }

   
}
