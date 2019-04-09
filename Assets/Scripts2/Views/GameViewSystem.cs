using UnityEngine;
using System.Collections;


public class GameViewSystem : MonoBehaviour
{
    public GameSystem gameSystem;
    private CardViewVariable activeCardView; 

    // Use this for initialization
    void Start()
    {
        gameSystem.InitializeGame();
    }
}
