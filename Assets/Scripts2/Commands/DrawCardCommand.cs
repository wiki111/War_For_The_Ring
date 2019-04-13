using UnityEngine;
using UnityEditor;

public class DrawCardCommand : Command
{
    private CardInstance cardToDraw;

    public DrawCardCommand(CardInstance cardToDraw)
    {
        this.cardToDraw = cardToDraw;
    }

    public override void Execute()
    {
        GameViewSystem.Instance.handController.DrawCard(cardToDraw);
        Complete();
    }
}