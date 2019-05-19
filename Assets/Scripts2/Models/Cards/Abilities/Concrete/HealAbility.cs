using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Game/Cards/Abilities/Heal Spell")]
public class HealAbility : SpellAbility
{
    public int healAmount;
    
    public override void ActivateAbility(List<Target> targets, AbilityInstance instance)
    {
        if(targets != null && targets.Count > 0)
        {
            new SpellCardActivateCommand(instance.owner.cardView).AddToQueue();

            foreach (Target target in targets)
            {
                target.Heal(healAmount);
            }

            instance.owner.RemoveCard();
        }
    }
    
}