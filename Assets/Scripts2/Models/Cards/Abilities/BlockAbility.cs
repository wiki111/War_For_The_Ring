using UnityEngine;
using UnityEditor;

[CreateAssetMenu(menuName = "Game/Cards/Abilities/Block Ability")]
public class BlockAbility : PassiveAbility
{
    public override AbilityInstance GetInstance(CardInstance owner)
    {
        BlockAbilityInstance blockAbilityInstance = new BlockAbilityInstance(owner, triggerEvent);
        return blockAbilityInstance;
    }
}