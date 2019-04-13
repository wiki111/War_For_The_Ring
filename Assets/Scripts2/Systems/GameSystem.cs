﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Systems/Game System")]
public class GameSystem : ScriptableObject
{
    public Encounter encounter;
    public StateVariable currentState;
    public PlayerData playerData;
    public PlayerData enemyData;
    public GameEvent OnChangeTurnEvent;
    public PlayerSystem playerSystem;

    public void ChangeState(State state)
    {
        this.currentState.Set(state);
    }

    public void InitializeGame()
    {
        SetupPlayer(encounter.player, playerData);
        SetupPlayer(encounter.enemy, enemyData);
    }

    private void SetupPlayer(Player player, PlayerData data)
    {
        player.hp.value = data.hp;
        player.resources.value = data.resources;
        player.side = data.side;
        player.name = data.name;

        player.hand.Clear();
        player.table.Clear();
        player.graveyard.Clear();
        player.deck.Clear();
        foreach(Card card in data.deck.cardsInDeck)
        {
            player.deck.Add(card);
        }
    }

   
    public void ChangeTurn()
    {
        encounter.ChangeTurn();
        OnChangeTurnEvent.Raise();
        playerSystem.DrawCardFromDeck();
        new ChangeTurnCommand().AddToQueue();
    }


}