using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayerScript : MonoBehaviour
{
    public GameEvent changeTurnEvent;
    public PlayerVariable currentPlayer;
    public Player aiPlayerData;
    public GameSystem gameSystem;
    public BoolVariable isAnimating;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isAnimating.value == false)
        {
            if (currentPlayer.value == aiPlayerData)
            {
                gameSystem.ChangeTurn();
            }
        }
        
    }
}
