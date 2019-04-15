using UnityEngine;
using UnityEditor;

public static class TargetingSystem 
{
    public static bool IsValid(TargetOptions validTargets, Target target)
    {
        switch (validTargets)
        {
            case TargetOptions.CardOnTable:
                return (target.IsValidTarget(TargetOptions.CardOnTable));
                break;
            case TargetOptions.CardAndEnemy:
                return target.IsValidTarget(TargetOptions.CardAndEnemy);
                break;
            case TargetOptions.Player:
                return target.IsValidTarget(TargetOptions.Player);
                break;
            case TargetOptions.Enemy:
                return target.IsValidTarget(TargetOptions.Enemy);
                break;
            default:
                return false;
                break;
        }
    }
}