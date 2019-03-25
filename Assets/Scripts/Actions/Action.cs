using UnityEngine;
using UnityEditor;
using TheLiquidFire.AspectContainer;
using TheLiquidFire.Notifications;

public class Action 
{
    public int id;
    public Player player;
    public int priority;
    public int orderOfPlay;
    public bool isCanceled;
    public Phase before;
    public Phase after;

    public Action()
    {
        id = Global.GenerateID(this.GetType());
        before = new Phase(this, BeforeKeyFrame);
        after = new Phase(this, AfterKeyFrame);
    }

    public virtual void BeforeKeyFrame(IContainer game)
    {
        var notifName = Global.PrepareNotification(this.GetType());
        game.PostNotification(notifName, this);
        Debug.Log("Posted notification : " + notifName);
    }

    public virtual void AfterKeyFrame(IContainer game)
    {
        var notifName = Global.PerformNotification(this.GetType());
        game.PostNotification(notifName, this);
        Debug.Log("Posted notification : " + notifName);
    }
}