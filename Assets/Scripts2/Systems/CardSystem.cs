using UnityEngine;
using UnityEditor;

public class CardSystem : ScriptableObject
{
    public PlayerSystem playerSystem;
    public GameEvent OnCardDrawnEvent;
    public GameEvent OnCardPlayedEvent;
    public CardVariable lastDrawnCard;
    public CardViewVariable currentCardViewActive;

    public void AddCardToGame(CardInstance cardInstance)
    {
        foreach(Effect effect in cardInstance.card.ability.effects)
        {
            effect.trigger.RegisterListener(effect);
        }
    }
}