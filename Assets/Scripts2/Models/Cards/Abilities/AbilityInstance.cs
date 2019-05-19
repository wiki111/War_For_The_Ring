using UnityEngine;
using UnityEditor;

public abstract class AbilityInstance 
{
    public CardInstance owner;
    public GameEvent ev;
    public abstract void RegisterAbility();
    public abstract void UnregisterAbility();
    public abstract void ActivateAbility(Action action);

    public AbilityInstance(CardInstance owner, GameEvent ev)
    {
        this.owner = owner;
        this.ev = ev;
    }

}