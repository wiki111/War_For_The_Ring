using UnityEngine;
using UnityEditor;
using TheLiquidFire.AspectContainer;
using TheLiquidFire.Notifications;
using System.Collections;
using System.Collections.Generic;

public class ActionSystem : Aspect
{
    public const string beginSequenceNotification = "ActionSystem.beginSequenceNotification";
    public const string endSequenceNotification = "ActionSystem.endSequenceNotification";
    public const string completeNotification = "ActionSystem.completeNotification";

    Action rootAction;
    IEnumerator rootSequence;
    List<Action> openReactions;
    public bool IsActive { get { return rootSequence != null; } }

    public void Perform(Action action)
    {
        if (IsActive) return;
        rootAction = action;
        rootSequence = Sequence(action);
    }

    public void Update()
    {
        if(rootSequence == null)
        {
            return;
        }

        if(rootSequence.MoveNext() == false)
        {
            rootAction = null;
            rootSequence = null;
            openReactions = null;
            this.PostNotification(completeNotification);
        }
    }

    public void AddReaction(Action action)
    {
        if(openReactions != null)
        {
            openReactions.Add(action);
        }
    }

    IEnumerator Sequence(Action action)
    {
        this.PostNotification(beginSequenceNotification, action);

        var phase = MainPhase(action.before);
        while (phase.MoveNext()) { yield return null; }

        phase = MainPhase(action.after);
        while (phase.MoveNext()) { yield return null; }

        this.PostNotification(endSequenceNotification, action);
    }

    IEnumerator MainPhase (Phase phase)
    {
        if (phase.owner.isCanceled)
        {
            yield break;
        }

        var reactions = openReactions = new List<Action>();
        var flow = phase.Flow(container);
        while (flow.MoveNext()) { yield return null; }

        flow = ReactPhase(reactions);
        while (flow.MoveNext()) { yield return null; }
    }

    IEnumerator ReactPhase(List<Action> reactions)
    {
        reactions.Sort(SortActions);
        foreach(Action reaction in reactions)
        {
            IEnumerator subFlow = Sequence(reaction);
            while (subFlow.MoveNext())
            {
                yield return null;
            }
        }
    }

    int SortActions(Action x, Action y)
    {
        if (x.priority != y.priority)
        {
            return y.priority.CompareTo(x.priority);
        }
        else
        {
            return x.orderOfPlay.CompareTo(y.orderOfPlay);
        }
    }
}

public static class ActionSystemExtensions
{
    public static void Perform(this IContainer game, Action action)
    {
        var actionSystem = game.GetAspect<ActionSystem>();
        actionSystem.Perform(action);
    }

    public static void AddReaction(this IContainer game, Action action)
    {
        var actionSystem = game.GetAspect<ActionSystem>();
        actionSystem.AddReaction(action);
    }
}