using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Game/Cards/Ability")]
public class Ability : ScriptableObject
{
    public List<Effect> effects = new List<Effect>();
}