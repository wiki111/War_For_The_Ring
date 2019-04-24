using UnityEngine;
using System.Collections;


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

    void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start()
    {
        gameSystem.InitializeGame();
    }
}
