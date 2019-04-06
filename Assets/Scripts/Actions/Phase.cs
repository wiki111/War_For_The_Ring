using UnityEngine;
using UnityEditor;
using System;
using TheLiquidFire.AspectContainer;
using System.Collections;
using Handler = System.Action<TheLiquidFire.AspectContainer.IContainer>;
using Viewer = System.Func<TheLiquidFire.AspectContainer.IContainer, Action, System.Collections.IEnumerator>;

public class Phase
{
    public Action owner;
    public Handler handler;
    public Viewer viewer;

    public Phase (Action owner, Handler handler)
    {
        this.owner = owner;
        this.handler = handler;
    }

    public IEnumerator Flow (IContainer game)
    {
        bool hitKeyFrame = false;

        if(viewer != null)
        {
            var sequence = viewer(game, owner);
            while (sequence.MoveNext())
            {
                var isKeyFrame = (sequence.Current is bool) ? (bool)sequence.Current : false;
                if (isKeyFrame)
                {
                    hitKeyFrame = true;
                    handler(game);
                }
                yield return null;
            }
        }

        if (!hitKeyFrame)
        {
            handler(game);
        }
    }
}