using UnityEngine;
using UnityEditor;

[CreateAssetMenu(menuName = "Game/Cards/Abilities/Block Ability")]
public class BlockAbility : PassiveAbility
{
    public override AbilityInstance GetInstance(CardInstance owner)
    {
        PassiveAbilityInstance blockAbilityInstance = new PassiveAbilityInstance(owner, this, triggerEvent);
        return blockAbilityInstance;
    }

    public override void ActivateAbility(Action action, PassiveAbilityInstance instance)
    {
        Debug.Log("Blooooock!");
        if (action is AttackAction)
        {
            if (((AttackAction)action).attacker.owner != instance.owner.owner)
            {
                ChangeTarget((AttackAction)action, instance.owner);
            }
        }
        else
        {
            throw new System.Exception("Invalid Action Exception - Block Ability can only handle AttackAction");
        }
    }

    private void ChangeTarget(AttackAction action, CardInstance newTarget)
    {
        action.target = newTarget;
    }

}