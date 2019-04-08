using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;

    [CreateAssetMenu(fileName = "NewPlayer", menuName = "Game/Player")]
    
    public class Player : ScriptableObject
    {

        public string name;
        public IntVariable hp;
        public IntVariable resources;
        public Side side;
        
        public List<Card> hand = new List<Card>();
        public List<Card> table = new List<Card>();
        public List<Card> graveyard = new List<Card>();
        public List<Card> deck = new List<Card>();
    }
    