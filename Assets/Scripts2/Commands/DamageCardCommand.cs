using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class DamageCardCommand : Command
{
    private CardView damagedCard;

    public DamageCardCommand(CardView damagedCard)
    {
        this.damagedCard = damagedCard;
    }

    public override void Execute()
    {
        Debug.Log("Card text should update...");
        damagedCard.UpdatePower();
        Complete();
    }
}