using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardLoader : MonoBehaviour {

    /// <summary>
    /// all the cards loaded into the game.
    /// </summary>
    public List<Card> allCards { private set; get; }

    /// <summary>
    /// Loads all cards.
    /// </summary>
    void Start()
    {
        allCards = new List<Card>();
        allCards.Add(new Card("Fire_Magic", 2, "Deal one damage to the opponent", x =>
        {
            x.AddHealth(-1);
        }));

        allCards.Add(new EffectCard("Shield", 1, "User gains 3 armor over three turns", 3,
        // play card
        null,
        // use card
        x =>
        {
            x.AddArmor(1);
        }));

        allCards.Add(new UnitCard("Demon", 3, "The gift from the gods you needed to win this match", 17, 2, null, null));
        allCards.Add(new UnitCard("Wazzlo", 2, "Some wizard guy from another realm, idunno.", 10, 10, null, null));
        allCards.Add(new UnitCard("Sorcerer", 5, "Long lost from another world, fights in an ever lasting battle", 5, 30, null, null));
        allCards.Add(new UnitCard("Snail", 1, "...or a frog?", 1, 5, null, null));
        allCards.Add(new UnitCard("Phoenix", 4, "also known as the fire chicken", 10, 5, null, null));
    }
}
