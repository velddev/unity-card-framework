using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    Transform canvas;

    public GameObject baseCard;
    CardLoader cardLoader;

    public CardPlaySlot[] places;

    public void Start()
    {
        cardLoader = GetComponent<CardLoader>();
        canvas = GameObject.Find("CardHolder_Local").transform;
        for(int i = 0; i < 7; i ++)
        {
            DrawCard();
        }
    }

    public void DrawCard()
    {
        GameObject g = (GameObject)Instantiate(baseCard, Vector3.zero, Quaternion.identity);
        g.transform.SetParent(canvas);
        g.GetComponent<CardObject>().Load(cardLoader.allCards[Random.Range(0, cardLoader.allCards.Count)]);
    }

    public void PlaceCard(Card card)
    {

    }
}
