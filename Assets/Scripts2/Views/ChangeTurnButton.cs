using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeTurnButton : MonoBehaviour, IPointerClickHandler
{
    public GameEvent ChangeTurnEvent;
    public BoolVariable isAnimating;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked change turn button ...");

        if (!isAnimating.value)
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
