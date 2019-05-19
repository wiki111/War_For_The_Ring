using UnityEngine;
using UnityEditor;

public class BlockAbilityInstance : AbilityInstance
{
    public BlockAbilityInstance(CardInstance owner, GameEvent ev) : base(owner, ev)
    {
    }

    public override void ActivateAbility(Action action)
    {
        Debug.Log("Blooooock!");
        if (action is AttackAction)
        {
            if(((AttackAction)action).attacker.owner != this.owner.owner)
            {
                ChangeTarget((AttackAction)action);
            }
        }
        else
        {
            throw new System.Exception("Invalid Action Exception - Block Ability can only handle AttackAction");
        }
    }

    private void ChangeTarget(AttackAction action)
    {
        action.target = this.owner;
    }

    public override void RegisterAbility()
    {
        this.ev.RegisterListener(this);
    }

    public override void UnregisterAbility()
    {
        this.ev.UnregisterListener(this);
    }
}