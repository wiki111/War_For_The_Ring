using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheLiquidFire.Notifications;
using TheLiquidFire.AspectContainer;

public class DrawCardsView : MonoBehaviour {

    public GameObject cardPrefab;
    public List<GameObject> handViews;

    private void OnEnable()
    {
        this.AddObserver(OnPrepareDrawCards, Global.PrepareNotification<DrawCardsAction>());
    }

    private void OnDisable()
    {
        this.RemoveObserver(OnPrepareDrawCards, Global.PrepareNotification<DrawCardsAction>());
    }


    void OnPrepareDrawCards(object sender, object args)
    {
        var action = args as DrawCardsAction;
        action.perform.viewer = DrawCardsViewer;
    }

    IEnumerator DrawCardsViewer(IContainer game, Action action)
    {
        yield return true;
        var drawAction = action as DrawCardsAction;
        
        for (int i = 0; i < drawAction.cards.Count; i++)
        {
            var cardView = Instantiate(cardPrefab).GetComponent<CardView>();
            cardView.card = drawAction.cards[i];
            cardView.transform.SetParent(handViews[drawAction.player.index].transform);
            Debug.Log("Drawn card");
        }
    }
}
