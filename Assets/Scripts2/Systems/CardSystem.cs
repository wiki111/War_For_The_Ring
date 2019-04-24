using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Game/Systems/Card System")]
public class CardSystem : ScriptableObject
{
    public PlayerSystem playerSystem;
    
    public void UseCard(CardInstance card, Target target)
    {
        if(card.numberOfUsesThisTurn < card.card.useLimit)
        {
            if (TargetingSystem.IsValid(card.card.validTargets, target))
            {
                target.Damage(card.power);
                card.numberOfUsesThisTurn++;
            }
        }
    }

    public void ResetCardUsage()
    {
        List<CardInstance> cardsToReset;

        cardsToReset = playerSystem.player.table;

        if(cardsToReset != null)
        {
            foreach (CardInstance card in cardsToReset)
            {
                card.numberOfUsesThisTurn = 0;
            }
        }
        
        cardsToReset = playerSystem.enemy.table;
         
        if (cardsToReset != null)
        {
            foreach (CardInstance card in cardsToReset)
            {
                card.numberOfUsesThisTurn = 0;
            }
        }
        
    }
}