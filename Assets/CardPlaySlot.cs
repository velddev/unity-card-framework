using UnityEngine;

public class CardPlaySlot : MonoBehaviour
{
    public Card cardInSpot;
    
    public bool isTaken()
    {
        return cardInSpot != null;
    }
}