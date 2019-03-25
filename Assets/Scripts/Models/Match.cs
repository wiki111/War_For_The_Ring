using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class Match 
{
    public const int playerCount = 2;
    public List<Player> players = new List<Player>();
    public int currentPlayerIndex;

    public Match()
    {
        players.Add(new Player(0));
        players.Add(new Player(1));
    }

    public Player GetCurrentPlayer()
    {
        return players[currentPlayerIndex];
    }
}