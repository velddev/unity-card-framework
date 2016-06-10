using UnityEngine;
using System.Collections;

public delegate void PlayCard(ITargetable p);
public delegate void UseCard(ITargetable p);

public enum Targetable { ALL, PLAYER_ONLY, CARD_ONLY, SELF, OPPONENT};

[System.Serializable]
public class Card {

    public string name;
    public string description;

    public int starValue;

    public Sprite card_image;

    PlayCard cardEffect;

    public Card(string name, int starValue, string description, PlayCard cardEffect)
    {
        this.name = name;
        this.starValue = starValue;
        this.description = description;
        if (cardEffect != null)
        {
            this.cardEffect = cardEffect;
        }
        card_image = Resources.Load<Sprite>("sprite_cards/" + name);
    }

    public void DoCardEffect(ITargetable t)
    {
        cardEffect(t);
        // destroy
    }
}

public class EffectCard:Card
{
    int turns;

    protected UseCard useEffect;

    public EffectCard(string name, int starValue, string description, int turns, PlayCard playEffect, UseCard useEffect) : base (name, starValue, description, playEffect)
    {
        turns = 0;
        this.useEffect = x =>
        {
            useEffect(x);
            turns--;
            if (turns <= 0)
            {
                // destroy effect
            }
        };
    }
}

public class UnitCard:EffectCard, ITargetable
{
    int attack;
    int health;

    public UnitCard(string name, int starValue, string description, int attack, int health, PlayCard playEffect, UseCard useEffect) : base(name, starValue, description, 0, playEffect, useEffect)
    {
        this.attack = attack;
        this.health = health;
        this.useEffect = x =>
        {

            useEffect(x);
        };
    }

            /// <summary>
            /// Adds "value" to current Health. Use this function if you want to lower health aswell.
            /// </summary>
            /// <param name="value">health added to target's current health pool.</param>
    public void AddHealth(int value)
    {
        health += value;
        if (!IsAlive())
        {
            //destroy
        }
    }

    /// <summary>
    /// Adds "value" to current Mana. Use this function if you want to lower mana aswell.
    /// </summary>
    /// <param name="value">mana added to target's current mana pool.</param>
    public void AddMana(int value)
    {
        
    }

    /// <summary>
    /// The amount of health the target has.
    /// </summary>
    /// <returns>health</returns>
    public int GetHealth()
    {
        return health;
    }

    /// <summary>
    /// The amount of mana the target has.
    /// </summary>
    /// <returns>mana</returns>
    public int GetMana()
    {
        return 0;
    }

    /// <summary>
    /// Adds armor to target, can be used to decrease armor aswell.
    /// </summary>
    /// <param name="value">armor added</param>
    public void AddArmor(int value)
    {

    }

    /// <summary>
    /// The amount of armor the target has. 
    /// </summary>
    /// <returns>armor</returns>
    public int GetArmor()
    {
        return 0;
    }

    /// <summary>
    /// Checks if the health of target is higher than 0
    /// </summary>
    /// <returns>if the target is alive or not.</returns>
    public bool IsAlive()
    {
        return health > 0;
    }

}