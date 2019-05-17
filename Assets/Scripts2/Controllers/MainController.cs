using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : Controller
{
    public GameViewSystem gameViewSystem;
    public CardController cardController;
    public BoolVariable isAnimating;

    protected override void HandleLeftMouseClick()
    {
        var objectClicked = GetObjectClicked();

        if (objectClicked != null)
        {
            Debug.Log(objectClicked.name);
            if (objectClicked.tag == "CardView" && !isAnimating.value)
            {
                Debug.Log("Main controller handles mouse click...");
                this.activeControl = false;
                cardController.Activate(objectClicked, objectClicked.GetComponent<CardView>().cardInstance.area);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        activeControl = true;
    }
}
