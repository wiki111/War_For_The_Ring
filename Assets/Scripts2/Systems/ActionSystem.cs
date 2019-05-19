using UnityEngine;
using UnityEditor;

[CreateAssetMenu(menuName = "Game/Systems/Action System")]
public class ActionSystem : ScriptableObject
{
    public GameEvent BeforeAttackActionEvent;
    public GameEvent AfterAttackActionEvent;

    public void ExecuteAction(Action action)
    {
        RaiseBeforeEvent(action);
        action.Execute();
        RaiseAfterEvent(action);
    }

    public void RaiseBeforeEvent(Action action)
    {
        if(action is AttackAction)
        {
            BeforeAttackActionEvent.RaiseActionEvent(action);
        }
    }

    public void RaiseAfterEvent(Action action)
    {
        if(action is AttackAction)
        {
            AfterAttackActionEvent.RaiseActionEvent(action);
        }
    }
}