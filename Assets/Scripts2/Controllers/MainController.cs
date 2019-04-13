﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : Controller
{
    public GameViewSystem gameViewSystem;
    public CardController cardController;

    protected override void HandleLeftMouseClick()
    {
        var objectClicked = GetObjectClicked();

        if (objectClicked != null)
        {
            Debug.Log(objectClicked.name);
            if (objectClicked.tag == "CardView")
            {
                Debug.Log("Main controller handles mouse click...");
                this.activeControl = false;
                cardController.Activate(objectClicked);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        activeControl = true;
    }
}