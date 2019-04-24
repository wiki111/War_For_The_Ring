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
    public int numberOfUsesThisTurn = 0;
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
        if(this.power <= 0)
        {
            new KillCardCommand(this).AddToQueue();
            RemoveCard();
        }
    }

    public void RemoveCard()
    {
        switch (this.area)
        {
            case Areas.Deck:
                owner.deck.Remove(this);
                break;
            case Areas.Hand:
                owner.hand.Remove(this);
                break;
            case Areas.Table:
                owner.table.Remove(this);
                Debug.Log("Card Removed");
                break;
            default:
                break;
        }

        owner.graveyard.Add(this);
        this.area = Areas.Graveyard;
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