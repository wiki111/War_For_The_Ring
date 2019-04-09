using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "NewSoldierCard", menuName = "Game/Cards/Soldier Card")]
public class Card : ScriptableObject
{
    public int id;
    public string name;
    public int power;
    public int cost;
    public string description;
    public CardType type;
    public Sprite artwork;
    public Ability ability;
}
