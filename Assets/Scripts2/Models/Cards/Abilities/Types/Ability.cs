using UnityEngine;
using UnityEditor;
using System.Collections.Generic;


public abstract class Ability : ScriptableObject
{
    public string name;
    public abstract AbilityInstance GetInstance(CardInstance owner);
}