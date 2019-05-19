using UnityEngine;
using UnityEditor;

public abstract class PassiveAbility : Ability
{
    public GameEvent triggerEvent;
    public abstract AbilityInstance GetInstance(CardInstance owner);
}