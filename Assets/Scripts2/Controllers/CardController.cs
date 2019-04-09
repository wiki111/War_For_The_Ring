using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : Controller
{
    public CardViewVariable activeCardViewVar;
    public PlayerSystem playerSystem;
    public GameEvent GiveUpControlEvent;
    public GameEvent OnCardPlacedOnTableEvent;
    private ControllerState currentControllerState;
    private ControllerState cardOnHandState;

    void Start()
    {
        activeControl = false;
        cardOnHandState = new CardOnHandState();
        cardOnHandState.owner = this;
    }

    public void Activate(GameObject activeCardView)
    {
        Debug.Log("CardController takes over control...");
        if (activeCardView.GetComponent<CardView>().cardInstance.owner != playerSystem.currentPlayer.value)
        {
            Debug.Log(activeCardView.GetComponent<CardView>().cardInstance.owner);
            Debug.Log(playerSystem.currentPlayer);
            GiveUpControl();
            return;
        }

        activeControl = true;
        activeCardViewVar.value = activeCardView;
        var cardView = activeCardView.GetComponent<CardView>();
        cardView.ToggleActive();
        currentControllerState = cardOnHandState;
    }

    protected override void HandleLeftMouseClick()
    {
        var handler = currentControllerState as ILeftMouseClickHandler;
        if (handler != null)
            handler.OnLeftMouseClick();
    }

    public void GiveUpControl()
    {
        Debug.Log("CardController gives up control...");
        currentControllerState = null;
        activeControl = false;
        GiveUpControlEvent.Raise();
    }

    private interface ILeftMouseClickHandler
    {
        void OnLeftMouseClick();
    }

    private abstract class ControllerState 
    {
        public CardController owner;
    }

    private class CardOnHandState : ControllerState, ILeftMouseClickHandler
    {
        public void OnLeftMouseClick()
        {
            var objectClicked = owner.GetObjectClicked();
            if(objectClicked != null)
            {
                if (objectClicked.GetComponent<PlayerTableView>() != null)
                {
                    if(owner.activeCardViewVar.value.GetComponent<CardView>().cardInstance.owner == owner.playerSystem.currentPlayer.value)
                    {
                        owner.playerSystem.PlaceCardOnTable();
                        owner.OnCardPlacedOnTableEvent.Raise();
                        objectClicked.GetComponent<PlayerTableView>().PlaceCard(owner.activeCardViewVar);
                        Complete();
                    }

                }
                else
                {
                    Complete();
                }
            }
            else
            {
                Complete();      
            }
        }

        private void Complete()
        {
            owner.activeCardViewVar.value.GetComponent<CardView>().ToggleActive();
            owner.activeCardViewVar.value = null;
            owner.GiveUpControl();
        }

    }
}


