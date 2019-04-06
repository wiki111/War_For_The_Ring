using UnityEngine;
using UnityEditor;

public abstract class CardViewLogic : ScriptableObject
{
    public abstract void OnClick(SCApproach.CardView card);
    public abstract SCApproach.CardView GetCurrentCard();
}