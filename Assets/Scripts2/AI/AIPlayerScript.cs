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
        if (isAnimating.value == false && currentPlayer.value == aiPlayerData)
        {

            PlayCards();
            UseCardsOnTable();
            UseSpells();
            //if(aiPlayerData.table.Count > 0)
            //{
            //    CardInstance cardToPlay = aiPlayerData.table[0];
            //    if(enemyData.table.Count > 0)
            //    {
            //        cardSystem.UseCard(cardToPlay, enemyData.table[0]);
            //    }
            //    else
            //    {
            //        cardSystem.UseCard(cardToPlay, enemyData);
            //    }
            //}

            if (currentPlayer.value == aiPlayerData)
            {
                gameSystem.ChangeTurn();
            }
        }
        
    }

    private void PlayCards()
    {
        if (HasCards())
        {
            foreach(CardInstance card in aiPlayerData.hand)
            {
                if (HasResources(card))
                {
                    gameSystem.cardSystem.PlaceCardOnTable(card.cardView, tableView);
                }
            }
        }
    }

    private void UseSpells()
    {
        foreach(CardInstance card in aiPlayerData.hand)
        {
            if(card.card.type == CardType.Spell)
            {
                SpellAbility ability = ((SpellAbility)card.card.ability);
                int numberOfTargets = ability.numberOfTargets;
                List<Target> targets = new List<Target>();
                for (int i = 0; i < numberOfTargets; i++)
                {
                    if(ability.validTargets == TargetOptions.EnemyCard && enemyData.table.Count - 1 >= i)
                    {
                        targets.Add(enemyData.table[i]);
                    }

                    if(ability.validTargets == TargetOptions.AllyCard && aiPlayerData.table.Count - 1 >= i)
                    {
                        targets.Add(aiPlayerData.table[i]);
                    }
                }

                if(targets.Count > 0)
                {
                    ability.ActivateAbility(targets, card.abilityInstance);
                }
            }
        }
    }

    private void UseCardsOnTable()
    {
        foreach (CardInstance card in aiPlayerData.table)
        {
            while (card.numberOfUsesThisTurn < card.card.useLimit)
            {
                Debug.Log("Using card " + card.card.name + " ...");
                cardSystem.UseCard(card, determineBestTarget());
            }
        }
    }

    private bool HasCards()
    {
        if(aiPlayerData.hand.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool HasResources(CardInstance card)
    {
        if(aiPlayerData.resources.value >= card.cost)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private Target determineBestTarget()
    {
        int enemyTablePower = 0;
        int aiTablePower = 0;
        int enemyHP = enemyData.hp.value;
        bool blockerOnEnemyTable = false;
        bool blockerOnAiTable = false;

        foreach(CardInstance card in enemyData.table)
        {
            enemyTablePower += card.power;
            if(card.card.type == CardType.Blocker)
            {
                blockerOnEnemyTable = true;
            }
        }

        foreach (CardInstance card in aiPlayerData.table)
        {
            if(card.card.useLimit > 0)
            {
                for (int i = 0; i < card.card.useLimit; i++)
                {
                    aiTablePower += card.power;
                }
            }
            
            if(card.card.type == CardType.Blocker)
            {
                blockerOnAiTable = true;
            }
        }

        //first, prevent losing
        if(enemyTablePower > aiPlayerData.hp.value && aiTablePower < enemyData.hp.value)
        {
            return findMostDangerousCard();  
        }

        if(enemyData.hp.value <= aiTablePower)
        {
            return enemyData;
        }

        Debug.Log("AI attacks player...");
        return enemyData;
    }

    private Target findMostDangerousCard()
    {
        CardInstance cardToAttack = null;
        foreach (CardInstance card in enemyData.table)
        {
            if(cardToAttack == null)
            {
                cardToAttack = card;
            }
            else if(cardToAttack.power < card.power && card.card.useLimit > 0)
            {
                cardToAttack = card;
            }
        }

        return cardToAttack;
    }

    
}
