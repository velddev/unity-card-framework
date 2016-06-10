using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour, ITargetable {
    public int Health;
    public int Armor;
    public int Mana;

    public List<Card> cardsInHand;

    
    /// <summary>
    /// Adds "value" to current Health. Use this function if you want to lower health aswell.
    /// </summary>
    /// <param name="value">health added to target's current health pool.</param>
    public void AddHealth(int value)
    {
        Health += value;
        if(!IsAlive())
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
        Mana += value;
        if (Mana < 0)
        {
            Mana = 0;
        }
    }

    /// <summary>
    /// The amount of health the target has.
    /// </summary>
    /// <returns>health</returns>
    public int GetHealth()
    {
        return Health;
    }

    /// <summary>
    /// The amout of mana the target has.
    /// </summary>
    /// <returns>mana</returns>
    public int GetMana()
    {
        return Mana;
    }

    public void AddArmor(int value)
    {
        Armor += value;
        if(Armor < 0)
        {
            Armor = 0;
        }
    }

    public int GetArmor()
    {
        return Armor;
    }

    /// <summary>
    /// Checks if the health of target is higher than 0
    /// </summary>
    /// <returns>if the target is alive or not.</returns>
    public bool IsAlive()
    {
        return Health > 0;
    }
}
