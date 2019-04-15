using UnityEngine;
using UnityEditor;

public class CardInstance : Target
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

    public override void Damage(int amount)
    {
        this.power -= amount;
        Debug.Log("Card damaged...");
        new DamageCardCommand(this.cardView).AddToQueue();
    }

    public override bool IsValidTarget(TargetOptions criteria)
    {
        switch (criteria)
        {
            case TargetOptions.CardAndEnemy:
                return (area == Areas.Table);
                break;
            case TargetOptions.CardOnTable:
                return (area == Areas.Table);
                break;
            default:
                return false;
                break;
        }
    }
}