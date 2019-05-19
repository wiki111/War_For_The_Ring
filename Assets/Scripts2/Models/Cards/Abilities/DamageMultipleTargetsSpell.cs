using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Game/Cards/Abilities/Damage Multiple Targets Spell")]
public class DamageMultipleTargetsSpell : SpellAbility
{
    public List<int> damageAmounts = new List<int>();
    public ActionSystem actionSystem;
    public GameEvent BeforeAttackActionEvent;
    
    public override void ActivateAbility(List<Target> targets)
    {
        int counter = 0;
        if(damageAmounts != null && targets != null) //check for nulls
        {
            if(targets.Count > 0) //check that there are any targets
            {
                new SpellCardActivateCommand(owner.cardView).AddToQueue();

                foreach (Target target in targets) //perform actions on all targets
                {
                    if(counter < damageAmounts.Count) //if there is a damage value for the next target
                    {
                        actionSystem.ExecuteAction(new AttackAction(target, this.owner, damageAmounts[counter]));
                        //target.Damage(damageAmounts[counter]); //apply damage
                        counter++; //increment counter of damage values to apply to targets
                    }
                    
                }
            }
        }

        this.owner.RemoveCard();
    }
}