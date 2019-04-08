using UnityEngine;
using UnityEditor;

public class CardInstance
{
    public Card card;
    public Player owner;
    public CardView cardView;

    public int  instanceId;
    public int power;
    public int cost;
    public Areas area;
    
    public CardInstance(Card card)
    {
        //TODO : write method to generate unique instance IDs
        this.card = card;
        this.power = card.power;
        this.cost = card.cost;
    }
}