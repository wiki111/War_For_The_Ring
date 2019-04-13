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
        
        public List<CardInstance> hand = new List<CardInstance>();
        public List<CardInstance> table = new List<CardInstance>();
        public List<CardInstance> graveyard = new List<CardInstance>();
        public List<CardInstance> deck = new List<CardInstance>();
    }
    