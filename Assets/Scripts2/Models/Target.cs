using UnityEngine;
using UnityEditor;

public abstract class Target : ScriptableObject
{
    public abstract void Damage(int amount);

    public abstract bool IsValidTarget(TargetOptions criteria);
}