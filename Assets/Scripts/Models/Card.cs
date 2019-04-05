using UnityEngine;
using UnityEditor;


public enum TargetingOptions
{
    NoTarget,
    AllCards,
    EnemyCards,
    YourCards,
    AllHero,
    EnemyHero,
    YourHero
}

public enum CardAbility
{
    None,
    Taunt,
    Charge
}


[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{


    [Header("General Info")]
    public string name;
    public string id;
    public int cost;
    public string description;
    public Zones zone;
    public int ownerIndex;
    public Sprite artwork;

    [Header("Creature Info")]
    public int attack;
    public int health;
    public CardAbility Ability;

    [Header("SpellInfo")]
    public string SpellScriptName;
    public int SpellAmount;
    public TargetingOptions Targets;

}