using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class TableController : MonoBehaviour, IPointerClickHandler
{
    public GameObject tableView;
    public GameEvent OnPlaceCardEvent;

    public void OnPointerClick(PointerEventData eventData)
    {
        OnPlaceCardEvent.Raise();
    }

    public void PlaceCard(CardViewVariable cardViewVar)
    {
        cardViewVar.value.transform.SetParent(tableView.transform);
        cardViewVar.ToggleCardActive();
    }
    
}
