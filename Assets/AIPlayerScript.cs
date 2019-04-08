using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayerScript : MonoBehaviour
{
    public GameEvent changeTurnEvent;
    public PlayerVariable currentPlayer;
    public Player aiPlayerData;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentPlayer.value == aiPlayerData)
        {
            changeTurnEvent.Raise();
        }
    }
}
