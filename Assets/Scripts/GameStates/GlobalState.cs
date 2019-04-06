using UnityEngine;
using UnityEditor;
using TheLiquidFire.AspectContainer;
using TheLiquidFire.Notifications;

public class GlobalState : Aspect, IObserve
{
    public void Awake()
    {
        this.AddObserver(OnBeginSequence, ActionSystem.beginSequenceNotification);
        this.AddObserver(OnCompleteAllActions, ActionSystem.completeNotification);
    }

    public void Destroy()
    {
        this.RemoveObserver(OnBeginSequence, ActionSystem.beginSequenceNotification);
        this.RemoveObserver(OnCompleteAllActions, ActionSystem.completeNotification);
    }

    void OnBeginSequence(object sender, object args)
    {
        container.ChangeState<SequenceState>();
        Debug.Log("Current state : Sequence state");
    }

    void OnCompleteAllActions(object sender, object args)
    {
        container.ChangeState<PlayerIdleState>();
        Debug.Log("Current state : player idle state");
    }
}