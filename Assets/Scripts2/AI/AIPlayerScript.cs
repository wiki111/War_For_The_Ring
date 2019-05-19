using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayerScript : MonoBehaviour
{
    public GameEvent changeTurnEvent;
    public PlayerVariable currentPlayer;
    public Player aiPlayerData;
    public Player enemyData;
    public GameSystem gameSystem;
    public CardSystem cardSystem;
    public BoolVariable isAnimating;
    public GameObject tableView;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isAnimating.value == false)
        {
            if(aiPlayerData.hand.Count > 0)
            {
                var cardToPlay = aiPlayerData.hand[0];
                gameSystem.cardSystem.PlaceCardOnTable(cardToPlay.cardView, tableView);
            }

            if(aiPlayerData.table.Count > 0)
            {
                CardInstance cardToPlay = aiPlayerData.table[0];
                if(enemyData.table.Count > 0)
                {
                    cardSystem.UseCard(cardToPlay, enemyData.table[0]);
                }
                else
                {
                    cardSystem.UseCard(cardToPlay, enemyData);
                }
            }

            if (currentPlayer.value == aiPlayerData)
            {
                gameSystem.ChangeTurn();
            }
        }
        
    }
}
