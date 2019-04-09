﻿using UnityEngine;
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
    public CardVariable lastDrawnCard;
    public CardViewVariable currectCardViewActive;
    public CardSystem cardSystem;
    
    public void DrawCardFromDeck()
    {
        if (currentPlayer.Get().deck.Count > 0)
        {
            Debug.Log("Drawing card (deck count of player " + currentPlayer.Get().name + " is " + currentPlayer.Get().deck.Count);
            Card drawnCard = currentPlayer.Get().deck[0];
            currentPlayer.Get().deck.RemoveAt(0);
            currentPlayer.Get().hand.Add(drawnCard);
            lastDrawnCard.Value = drawnCard;
            OnCardDrawnEvent.Raise();
        }

    }

    public void PlaceCardOnTable()
    {
        Debug.Log("Player owns card placed is : " + CheckIfCardInPlayersHand(currectCardViewActive));
        Card cardToPlace = currectCardViewActive.Get().cardInstance.card;
        currentPlayer.Get().hand.Remove(cardToPlace);
        currentPlayer.Get().table.Add(cardToPlace);
    }

    private bool CheckIfCardInPlayersHand(CardViewVariable cardViewVar)
    {
        return currentPlayer.Get().hand.Contains(cardViewVar.Get().cardInstance.card);
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

