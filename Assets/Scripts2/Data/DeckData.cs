using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Game/Data/Deck Data")]
public class DeckData : ScriptableObject
{
    public List<SCApproach.Card> cardsInDeck = new List<SCApproach.Card>();
}