using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameViewSystem : MonoBehaviour
{
    public GameSystem gameSystem;
    private CardViewVariable activeCardView;
    public InfoTextView infoTextView;
    public HandController handController;
    public static GameViewSystem Instance;
    public PlayerViewContainer playersViews;
    public PlayerViewContainer enemyViews;
    public BoolVariable isAnimating;
    public Canvas EndgameScreen;

    void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start()
    {
        gameSystem.InitializeGame();
    }

    public void EndGame(Player winner)
    {
        Text infoText = EndgameScreen.GetComponentInChildren<Text>();
        if (winner == gameSystem.encounter.player)
        {
            infoText.text = "You Win";
        }
        else
        {
            infoText.text = "You Lose";
        }
        EndgameScreen.gameObject.SetActive(true);
        gameSystem.gameEnded.value = true;
    }
}
