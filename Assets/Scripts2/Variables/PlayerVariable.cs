using UnityEngine;
using UnityEditor;

[CreateAssetMenu(menuName = "Game/Variables/PlayerVariable")]
public class PlayerVariable : ScriptableObject
{
    public SCApproach.Player value;

    public void Set(SCApproach.Player player)
    {
        this.value = player;
    }

    public SCApproach.Player Get()
    {
        return this.value;
    }
}