using UnityEngine;
using UnityEditor;

[CreateAssetMenu(menuName = "Game/Systems/Player System")]
public class PlayerSystem : ScriptableObject
{
    public PlayerVariable currentPlayer;
    public Player player;
    public Player enemy;
    public GameEvent OnCardDrawnEvent;
    public GameEvent OnCardPlacedOnTableEvent;
    public GameEvent OnPlayerDamaged;
    public CardInstanceVariable lastDrawnCard;
    public CardViewVariable currectCardViewActive;
    public CardSystem cardSystem;
    
    public void DrawCardFromDeck()
    {
        if (currentPlayer.Get().deck.Count > 0)
        {
            CardInstance drawnCard = currentPlayer.Get().deck[0];
            drawnCard.area = Areas.Hand;
            drawnCard.owner = currentPlayer.Get();
            currentPlayer.Get().deck.RemoveAt(0);
            currentPlayer.Get().hand.Add(drawnCard);
            lastDrawnCard.CardInstance = drawnCard;
            Debug.Log(lastDrawnCard.CardInstance);
            new DrawCardCommand(drawnCard).AddToQueue();
            OnCardDrawnEvent.Raise();
        }

    }

    public void PlaceCardOnTable(CardViewVariable placedCardViewVar, GameObject tableView)
    {
        CardInstance cardToPlace = currectCardViewActive.Get().cardInstance;
        currentPlayer.Get().hand.Remove(cardToPlace);
        cardToPlace.area = Areas.Table;
        currentPlayer.Get().table.Add(cardToPlace);
        new PlaceCardOnTableCommand(placedCardViewVar, tableView.GetComponent<PlayerTableView>()).AddToQueue();
        OnCardPlacedOnTableEvent.Raise();
    }

    private bool CheckIfCardInPlayersHand(CardViewVariable cardViewVar)
    {
        return currentPlayer.Get().hand.Contains(cardViewVar.Get().cardInstance);
    }

    public void DamagePlayer(Player player, int amount)
    {
        if (CanDamagePlayer())
        {
            player.hp.value = player.hp.value - amount;
            OnPlayerDamaged.Raise();
        }
    }

    private bool CanDamagePlayer()
    {
        return true;
    }

    
}

