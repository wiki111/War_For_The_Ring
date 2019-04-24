using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : Controller
{
    public CardViewVariable activeCardViewVar;
    public PlayerSystem playerSystem;
    public CardSystem cardSystem;
    public GameEvent GiveUpControlEvent;
    public GameEvent OnCardPlacedOnTableEvent;
    private ControllerState currentControllerState;
    private bool missUpdate;

    void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        activeControl = false;
        missUpdate = true;
    }

    private void Reset()
    {
        Debug.Log("Card controller gives up control...");
        missUpdate = true;
        currentControllerState = null;
        activeControl = false;
    }

    public void Activate(GameObject activeCardView, Areas cardLocation)
    {
        Debug.Log("Card controller takes over...");
        if (!PlayerOwnsCard(activeCardView))
        {
            Debug.Log("Player doesn't own card - returning control to Main Controller ...");
            GiveUpControl();
            return;
        }

        if(cardLocation == Areas.Hand)
        {
            CardOnHandStateInit(activeCardView);
        }

        if(cardLocation == Areas.Table)
        {
            CardAttackConfirmStateInit(activeCardView);
        }

        if(currentControllerState == null)
        {
            GiveUpControl();
        }
    }

    void ChangeCurrentState(ControllerState state)
    {
        this.currentControllerState = state;
        state.owner = this;
    }

    void CardOnHandStateInit(GameObject activeCardView)
    {
        Debug.Log("Card controller switches to CardOnHandState...");
        activeCardViewVar.value = activeCardView;
        var cardView = activeCardView.GetComponent<CardView>();
        cardView.ToggleActive();
        activeControl = true;
        ChangeCurrentState(new CardOnHandState());
    }

    void CardAttackConfirmStateInit(GameObject activeCardView)
    {
        Debug.Log("Card controller switches to CardAttackConfirmState...");
        activeCardViewVar.value = activeCardView;
        var cardView = activeCardView.GetComponent<CardView>();
        cardView.ToggleActive();
        activeControl = true;
        ChangeCurrentState(new CardAttackConfirmState());
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
            if (!owner.missUpdate) {
                InvokePlaceCardOnTable();
            }
            else
            {
                if (owner.missUpdate)
                {
                    owner.missUpdate = false;
                }
            }
        }

        private void InvokePlaceCardOnTable()
        {
            var objectClicked = owner.GetObjectClicked();
            if (objectClicked != null)
            {
                if (objectClicked.GetComponent<PlayerTableView>() != null)
                {
                    if (owner.activeCardViewVar.value.GetComponent<CardView>().cardInstance.owner == owner.playerSystem.currentPlayer.value)
                    {
                        owner.playerSystem.PlaceCardOnTable(owner.activeCardViewVar.value.GetComponent<CardView>(), objectClicked);
                    }
                }
            }
            Complete();
        }

        private void Complete()
        {
            owner.activeCardViewVar.value.GetComponent<CardView>().ToggleActive();
            owner.activeCardViewVar.value = null;
            owner.GiveUpControl();
        }
    }

    private class CardAttackConfirmState : ControllerState, ILeftMouseClickHandler
    {
        public void OnLeftMouseClick()
        {
            if (!owner.missUpdate)
            {
                InvokeCardAttack();
            }
            else
            {
                owner.missUpdate = false;
            }
            
        }

        private void InvokeCardAttack()
        {
            var objectClicked = owner.GetObjectClicked();
            
            if(objectClicked != null)
            {
                if(objectClicked.GetComponent<PlayerView>() != null)
                {
                    Debug.Log("Confirmed target is a player...");
                    owner.cardSystem.UseCard(owner.activeCardViewVar.value.GetComponent<CardView>().cardInstance, objectClicked.GetComponent<PlayerView>().owner);
                }

                if(objectClicked.GetComponent<CardView>() != null)
                {
                    Debug.Log("Confirmed target is a card...");
                    owner.cardSystem.UseCard(owner.activeCardViewVar.value.GetComponent<CardView>().cardInstance, objectClicked.GetComponent<CardView>().cardInstance);
                }
                
            }

            Complete();
        }

        
        
        private void Complete()
        {
            owner.activeCardViewVar.value.GetComponent<CardView>().ToggleActive();
            owner.activeCardViewVar.value = null;
            owner.GiveUpControl();
        }

    }
}


