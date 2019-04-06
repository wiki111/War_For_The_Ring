using UnityEngine;
using UnityEditor;

[CreateAssetMenu(menuName = "Game/Card/Logic/Hand Card View Logic")]
public class HandCardViewLogic : CardViewLogic
{
    public CardViewVariable currentCardView;
    public PlayerVariable currentPlayer;
    public SCApproach.Player localPlayer;

    public override SCApproach.CardView GetCurrentCard()
    {
        return currentCardView.Get();
    }

    public override void OnClick(SCApproach.CardView card)
    {
        if (currentPlayer.Get() == card.owner && localPlayer == currentPlayer.Get())
        {
            if (currentCardView.Get() == null)
            {
                currentCardView.Set(card.gameObject);
                currentCardView.Get().ToggleActive();
            }
            else
            {
                currentCardView.Get().ToggleActive();

                if (currentCardView.Get() == card)
                {
                    currentCardView.Set(null);
                }
                else
                {
                    currentCardView.Set(card.gameObject);
                    currentCardView.Get().ToggleActive();
                }
            }
        }
        
    }

    
}