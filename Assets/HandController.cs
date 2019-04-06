using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SCApproach;

public class HandController : MonoBehaviour
{
    public GameObject cardPrefab;
    public GameObject handView;
    public SCApproach.Player owner;
    public PlayerVariable currentPlayer;

    public void DrawCard(CardVariable card)
    {
        if(owner == currentPlayer.Get())
        {
            var cardView = Instantiate(cardPrefab).GetComponent<SCApproach.CardView>();
            cardView.owner = currentPlayer.Get();
            cardView.card = card.Value;
            cardView.transform.SetParent(handView.transform);
        }
    }
}
