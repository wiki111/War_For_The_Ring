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
    private int missUpdateCounter = 0;

    void Start()
    {
        activeControl = false;
        missUpdateCounter = 0;
        cardOnHandState = new CardOnHandState();
        cardOnHandState.owner = this;
    }

    public void Activate(GameObject activeCardView)
    {
        Debug.Log("CardController takes over control...");
        Debug.Log(activeCardView.GetComponent<CardView>().cardInstance.owner);
        Debug.Log(playerSystem.currentPlayer.value);
        if (activeCardView.GetComponent<CardView>().cardInstance.owner != playerSystem.currentPlayer.value)
        {
            GiveUpControl();
            return;
        }

        activeCardViewVar.value = activeCardView;
        var cardView = activeCardView.GetComponent<CardView>();
        cardView.ToggleActive();
        currentControllerState = cardOnHandState;
        activeControl = true;
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
        missUpdateCounter = 0;
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
            if (owner.missUpdateCounter != 0) {
                var objectClicked = owner.GetObjectClicked();
                if (objectClicked != null)
                {
                    if (objectClicked.GetComponent<PlayerTableView>() != null)
                    {
                        if (owner.activeCardViewVar.value.GetComponent<CardView>().cardInstance.owner == owner.playerSystem.currentPlayer.value)
                        {
                            owner.playerSystem.PlaceCardOnTable(owner.activeCardViewVar, objectClicked);
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
            else
            {
                if (owner.missUpdateCounter == 0)
                {
                    owner.missUpdateCounter++;
                }
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


