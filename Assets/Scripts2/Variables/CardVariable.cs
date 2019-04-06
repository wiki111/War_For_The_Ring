using UnityEngine;
using UnityEditor;
using SCApproach;
using System;

[CreateAssetMenu(menuName = "Game/Variables/Card Variable")]
[Serializable]
public class CardVariable : ScriptableObject
{
    [SerializeField]
    public SCApproach.Card value;
    
    public SCApproach.Card Value
    {
        get
        {
            return value;
        }

        set
        {
            this.value = value;
        }
    }
}