using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class CardView : MonoBehaviour, IPointerClickHandler{

    public Card card;
    private bool isActive = false;
    public CardViewLogic currentLogic;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked card");
        //currentLogic.OnClick(this);
    }
    
    public void ToggleActive()
    {
        if (isActive)
        {
            this.transform.localScale = Vector3.one;
            this.isActive = false;
        }
        else
        {
            this.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
            this.isActive = true;
        }
    }
}
