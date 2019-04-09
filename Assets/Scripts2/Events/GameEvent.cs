using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Game/Event")]
public class GameEvent : ScriptableObject
{
    private List<GameEventListener> listeners = new List<GameEventListener>();
    private List<ScriptableEventListener> scriptableListeners = new List<ScriptableEventListener>();

    public void Raise()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised();
        }

        for (int i = scriptableListeners.Count - 1; i >= 0; i--)
        {
            scriptableListeners[i].OnEventRaised();
        }
    }
    
    public void RegisterListener(GameEventListener listener)
    {
        listeners.Add(listener);
    }

    public void RegisterListener(ScriptableEventListener listener)
    {
        scriptableListeners.Add(listener);
    }

    public void UnregisterListener(GameEventListener listener)
    {
        listeners.Remove(listener);
    }

    public void UnregisterListener(ScriptableEventListener listener)
    {
        scriptableListeners.Add(listener);
    }
}