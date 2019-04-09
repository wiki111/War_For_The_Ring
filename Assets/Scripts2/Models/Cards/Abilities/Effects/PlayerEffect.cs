using UnityEngine;
using UnityEditor;

[CreateAssetMenu(menuName = "Game/Cards/Effects/Player Effect")]
public class PlayerEffect : Effect
{
    public Player targetPlayer;
    public PlayerSystem playerSystem;
    public int amount;

    public override void OnEventRaised()
    {
        playerSystem.DamagePlayer(targetPlayer, amount);
    }
}