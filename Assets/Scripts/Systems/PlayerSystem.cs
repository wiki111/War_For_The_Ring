using UnityEngine;
using UnityEditor;
using TheLiquidFire.AspectContainer;
using TheLiquidFire.Notifications;
public class PlayerSystem : Aspect, IObserve
{

    public void Awake()
    {
        this.AddObserver(OnPerformChangeTurn, Global.PerformNotification<ChangeTurnAction>(), container);
        this.AddObserver(OnDrawCards, Global.PerformNotification<DrawCardsAction>(), container);
    }

    public void Destroy()
    {
        this.RemoveObserver(OnPerformChangeTurn, Global.PerformNotification<ChangeTurnAction>(), container);
        this.RemoveObserver(OnDrawCards, Global.PerformNotification<DrawCardsAction>(), container);
    }

    void OnPerformChangeTurn(object sender, object args)
    {
        var action = args as ChangeTurnAction;
        var match = container.GetAspect<DataSystem>().match;
        var player = match.players[action.targetPlayerIndex];
        DrawCards(player, 1);
    }

    void OnDrawCards(object sender, object args)
    {
        var action = args as DrawCardsAction;
        action.cards = action.player.deck.Draw(action.amount);
        foreach (Card card in action.cards)
        {
            Debug.Log("Drawn card owner index is : " + card.ownerIndex);
            card.zone = Zones.Hand;
        }
        action.player.hand.AddRange(action.cards);
    }

    void DrawCards(Player player, int amount)
    {
        var action = new DrawCardsAction(player, amount);
        container.AddReaction(action);
    }
}