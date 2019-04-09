using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PlayerTableView : MonoBehaviour
{
    public GameObject tableView;
    
    public void PlaceCard(CardViewVariable cardViewVar)
    {
        cardViewVar.value.transform.SetParent(tableView.transform);
    }
    
}
