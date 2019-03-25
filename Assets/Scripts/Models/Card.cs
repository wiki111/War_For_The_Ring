using UnityEngine;
using UnityEditor;

public class Card 
{
    public string name;
    public string id;
    public int power;
    public int cost;
    public Zones zone;
    public int ownerIndex;

    public Card()
    {
        zone = Zones.Deck;
        ownerIndex = 0;
    }

}