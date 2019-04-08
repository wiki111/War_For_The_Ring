using UnityEngine;
using System.Collections;


    public class GameViewSystem : MonoBehaviour
    {
        public GameSystem gameSystem;

        // Use this for initialization
        void Start()
        {
            gameSystem.InitializeGame();
        }
        
    }
