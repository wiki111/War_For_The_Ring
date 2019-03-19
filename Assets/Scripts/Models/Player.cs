using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class Player
{
    public string name;
    public int hp;
    public int resources;

    public List<Card> hand = new List<Card>();
    public List<Card> table = new List<Card>();
    public List<Card> graveyard = new List<Card>();
    public List<Card> deck = new List<Card>();
}