using UnityEngine;
using UnityEditor;

public class DrawCardCommand : Command
{
    private CardVariable cardToDraw;

    public DrawCardCommand(CardVariable cardToDraw)
    {
        this.cardToDraw = cardToDraw;
    }

    public override void Execute()
    {
        GameViewSystem.Instance.handController.DrawCard(cardToDraw);
        Complete();
    }
}