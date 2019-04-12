using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeTurnButton : MonoBehaviour, IPointerClickHandler
{
    public GameSystem gameSystem;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked change turn button ...");

        gameSystem.encounter.ChangeTurn();
        
    }
}
