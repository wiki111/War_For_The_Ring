using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeTurnButton : MonoBehaviour, IPointerClickHandler
{
    public GameEvent ChangeTurnEvent;
    public BoolVariable isAnimatingLockVariable;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked change turn button ...");

        if (!isAnimatingLockVariable.value)
        {
            Debug.Log("Raising ChangeTurnEvent...");
            ChangeTurnEvent.Raise();
        }
        else
        {
            return;
        }
        
    }
}
