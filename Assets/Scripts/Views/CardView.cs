using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{

    public Card card;
    public CardView PreviewManager;
    public Image cardBack;
    public Image cardFront;
    public Image im;
    public Text healthText;
    public Text attackText;
    public Text manaText;
    public Text titleText;
    public Text cardText;
    // Use this for initialization
    void Awake()
    {
        if (card != null)
            ReadCardFromAsset();
    }


    public void ReadCardFromAsset()
    {

        titleText.text = card.name;
        manaText.text = card.cost.ToString();
        cardText.text = card.description;
        im.sprite = card.artwork;

        if (card.health != 0)
        {
            // this is a creature
            attackText.text = card.attack.ToString();
            healthText.text = card.health.ToString();
        }

        if (PreviewManager != null)
        {

            PreviewManager.card = card;
            PreviewManager.ReadCardFromAsset();
        }
    }


}
