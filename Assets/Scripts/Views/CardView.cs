using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardView : MonoBehaviour {

    public Card card;
    public Zones zone;
    public int playerIndex;

	// Use this for initialization
	void Start () {
        this.card = new Card();
        this.card.zone = zone;
        this.card.ownerIndex = playerIndex;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
