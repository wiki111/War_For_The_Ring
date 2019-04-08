using UnityEngine;
using UnityEditor;

    public abstract class Card : ScriptableObject
    {
        public int id;
        public string name;
        public int power;
        public int cost;
        public string description;
        public Sprite artwork;
    }
