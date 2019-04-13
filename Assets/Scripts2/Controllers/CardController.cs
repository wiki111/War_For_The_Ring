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
    private int missUpdateCounter = 0;

    void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        activeControl = false;
        missUpdateCounter = 0;
    }

    private void Reset()
    {
        Debug.Log("Card controller gives up control...");
        missUpdateCounter = 0;
        currentControllerState = null;
        activeControl = false;
    }

    public void Activate(GameObject activeCardView, Areas cardLocation)
    {
        if (!PlayerOwnsCard(activeCardView))
        {
            GiveUpControl();
            return;
        }

        switch (cardLocation)
        {
            case Areas.Hand:
                CardOnHandStateInit(activeCardView);
                break;
        }
    }

    void ChangeCurrentState(ControllerState state)
    {
        this.currentControllerState = state;
        state.owner = this;
    }

    void CardOnHandStateInit(GameObject activeCardView)
    {
        activeCardViewVar.value = activeCardView;
        var cardView = activeCardView.GetComponent<CardView>();
        cardView.ToggleActive();
        activeControl = true;
        ChangeCurrentState(new CardOnHandState());
    }

    bool PlayerOwnsCard(GameObject activeCardView)
    {
        if (activeCardView.GetComponent<CardView>().cardInstance.owner != playerSystem.currentPlayer.value)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    protected override void HandleLeftMouseClick()
    {
        var handler = currentControllerState as ILeftMouseClickHandler;
        if (handler != null)
            handler.OnLeftMouseClick();
    }

    public void GiveUpControl()
    {
        Reset();
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


