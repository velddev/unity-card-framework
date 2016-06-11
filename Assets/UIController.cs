using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIController : MonoBehaviour {

    Player p;

    public static UIController instance;
    public List<RectTransform> cards = new List<RectTransform>();

    public RectTransform CardHolder;
    public RectTransform canvas;

    float cardWidth = 150;
    public float maxWidth;

    void Start()
    {
        instance = this;
        p = GameObject.Find("LocalPlayer").GetComponent<Player>();
    }

    void Update()
    {
        int offset = 0;
        float amountToRemove = (Screen.width - Screen.width * 0.4f) / (cards.Count + 1);
        for (int i = 0; i < cards.Count; i++)
        {
            if (!cards[i].GetComponent<CardObject>().isBeingInteracted)
            {
                if (cards[i].GetComponent<CardObject>().isSelected && i != cards.Count -1)
                {
                    cards[i].SetAsLastSibling();
                    offset++;
                }
                else
                {
                    cards[i].SetSiblingIndex(i - offset);
                }
                cards[i].transform.position = Vector3.Lerp(cards[i].transform.position, new Vector3((Screen.width - Screen.width * 0.8f) + amountToRemove * (i + 1), cards[i].position.y + cards[i].GetComponent<CardObject>().offsetY, 0), 5f * Time.deltaTime);
                cards[i].transform.localPosition = Vector3.Lerp(cards[i].transform.localPosition, new Vector3(cards[i].localPosition.x, 0, 0), 5f * Time.deltaTime);
            }
            else
            {
            }
        }
    }

    public void AddCard(RectTransform card)
    {
        if (cards.Contains(card))
        {
            if (CanMove(card))
            {
                Debug.Log("Can Move");
                RemoveCard(card);
            }
            else
            {
                Debug.Log("Can NOT Move");
                return;
            }
        }
        Debug.Log("Sorting..");
        cards.Add(card);
        cards.Sort((x, y) =>
        {
           return x.transform.position.x.CompareTo(y.transform.position.x);
        });
    }

    public int GetCardID(RectTransform card)
    {
        for(int i = 0; i < cards.Count; i++)
        {
            if(cards[i] == card)
            {
                return i;
            }
        }
        return -1;
    }

    public bool CanMove(RectTransform card)
    {
        float amountToRemove = (Screen.width - Screen.width * 0.4f) / (cards.Count + 1);

        return Vector3.Distance(card.transform.position, new Vector3((Screen.width - Screen.width * 0.8f) + amountToRemove * (GetCardID(card) + 1), card.position.y, 0)) > 100;

    }

    public void RemoveCard(RectTransform card)
    {
        cards.Remove(card);
    }
}
