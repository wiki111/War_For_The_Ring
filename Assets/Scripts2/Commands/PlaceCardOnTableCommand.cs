using UnityEngine;
using UnityEditor;

public class PlaceCardOnTableCommand : Command
{
    public CardViewVariable cardViewVar;
    public PlayerTableView tableView;

    public PlaceCardOnTableCommand(CardViewVariable cardViewVar, PlayerTableView tableView)
    {
        this.cardViewVar = cardViewVar;
        this.tableView = tableView;
    }

    public override void Execute()
    {
        tableView.PlaceCard(cardViewVar);
        Complete();
    }

}