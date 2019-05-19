using UnityEngine;
using UnityEditor;

public abstract class Action
{
    public abstract void BeforeExecute();
    public abstract void Execute();
    public abstract void AfterExecute();
}