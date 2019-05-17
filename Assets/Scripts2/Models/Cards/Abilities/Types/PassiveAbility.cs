using UnityEngine;
using UnityEditor;

public abstract class PassiveAbility : Ability
{
    public CardSystem cardSystem;
    public TargetOptions validTargets;
    public abstract void RegisterEffect();
    public abstract void UnregisterEffect();
}