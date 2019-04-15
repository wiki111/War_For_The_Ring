using UnityEngine;
using UnityEditor;

public class DamagePlayerCommand : Command
{
    public override void Execute()
    {
        PlayerView playerView = GameViewSystem.Instance.playersViews.GetComponentInChildren<PlayerView>();
        PlayerView enemyView = GameViewSystem.Instance.enemyViews.GetComponentInChildren<PlayerView>();
        playerView.UpdatePlayerHPText();
        enemyView.UpdatePlayerHPText();
        Complete();
    }
}