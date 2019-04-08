using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


    public class CardView : MonoBehaviour, IPointerClickHandler
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

        public void OnPointerClick(PointerEventData eventData)
            {
                Debug.Log("Clicked card");
                currentLogic.OnClick(this);
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
    }


