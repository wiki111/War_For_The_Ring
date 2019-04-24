using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class CardView : MonoBehaviour
{

    public CardInstance cardInstance;
    private bool isActive = false;
    public CardViewLogic currentLogic;

    public Image cardBack;
    public Image cardFront;
    public Image im;
    public Text healthText;
    public Text attackText;
    public Text manaText;
    public Text titleText;
    public Text cardText;

    public void OnEnable()
    {
        InitCardView();
    }

    private void InitCardView()
    {
        titleText.text = cardInstance.card.name;
        manaText.text = cardInstance.card.cost.ToString();
        attackText.text = cardInstance.card.power.ToString();
        cardText.text = cardInstance.card.description;
        im.sprite = cardInstance.card.artwork;
    }
    

    public void ToggleActive()
    {
        if (isActive)
        {
            this.transform.localScale = Vector3.one;
            this.isActive = false;
        }
        else
        {
            this.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
            this.isActive = true;
        }
    }

    public void UpdatePower()
    {
        Debug.Log("Updating card " + this + " power text ...");
        healthText.text = cardInstance.power.ToString();
    }

    public void KillCardAnimation()
    {
        StartCoroutine(ShrinkDown(this.transform));
    }

    public void DestroyCard()
    {
        Destroy(this.gameObject);
    }

    IEnumerator ShrinkDown(Transform target)
    {
        while (target.localScale.x > 0 || target.localScale.y > 0)
        {
            target.localScale = Vector3.Lerp(target.localScale, new Vector3(-0.5f, -0.5f, -0.5f), Time.deltaTime);
            yield return null;
        }
        DestroyCard();
    }
}


