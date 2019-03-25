using UnityEngine;
using UnityEditor;

public class ChangeTurnAction : Action
{
    public int targetPlayerIndex;

    public ChangeTurnAction(int targetPlayerIndex)
    {
        this.targetPlayerIndex = targetPlayerIndex;
    }
}