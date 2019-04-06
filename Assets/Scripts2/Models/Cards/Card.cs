using UnityEngine;
using UnityEditor;

namespace SCApproach{
    public abstract class Card : ScriptableObject
    {
        public string name;
        public string id;
        public int power;
        public int cost;
        public Areas area;
    }
}
