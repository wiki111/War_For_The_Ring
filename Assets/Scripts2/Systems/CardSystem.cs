using UnityEngine;
using UnityEditor;

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
}