using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class CardObject : MonoBehaviour {

    public bool isBeingInteracted = false;
    bool onPlayingField;
    public float offsetY = 0;
    public bool isSelected;

    #region UI Elements
    RectTransform rect;
    Image image;
    Text text;
    Slider starValue;
    #endregion
    EventSystem eventSystem;

    Card card;

    public void Load(Card card)
    {
        rect = GetComponent<RectTransform>();
        image = transform.GetChild(0).GetComponent<Image>();
        text = transform.GetComponentInChildren<Text>();
        starValue = transform.GetComponentInChildren<Slider>();
        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();

        this.card = card;
        image.sprite = card.card_image;
        text.text = "<b>" + card.name.Replace('_', ' ') + "</b>\n\n" + card.description;
        starValue.value = card.starValue;
        UIController.instance.AddCard((RectTransform)transform);
    }

    public void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, (isSelected ? Vector3.one : Vector3.one / 1.5f), 5 * Time.deltaTime);

    }

    public void OnMouseup(BaseEventData eventData)
    {
        isBeingInteracted = false;
        if(!onPlayingField)
        {
            UIController.instance.AddCard(rect);
            transform.parent = UIController.instance.CardHolder;
        }
    }

    public void OnMouseOver(BaseEventData eventData)
    {
        isSelected = true;
        offsetY = 20;
    }

    public void OnMouseOut(BaseEventData eventData)
    {
        isSelected = false;
        offsetY = 0;
    }

    public void OnDrag(BaseEventData eventData)
    {
        PointerEventData pointerData = eventData as PointerEventData;
        if (pointerData == null) {
            return; }
        isBeingInteracted = true;


        var currentPosition = rect.position;
        transform.parent = UIController.instance.canvas;

        if (Vector2.Distance(new Vector2(0, currentPosition.y), new Vector2(0, UIController.instance.CardHolder.position.y)) > 100)
        {
            UIController.instance.RemoveCard(rect);
        }
        else
        {
            UIController.instance.AddCard(rect);
            transform.parent = UIController.instance.CardHolder;
        }

        currentPosition.x += pointerData.delta.x;
        currentPosition.y += pointerData.delta.y;
        rect.position = currentPosition;
        
    }
}
