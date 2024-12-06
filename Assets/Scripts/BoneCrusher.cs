using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneCrusher : Decomposer
{
    public override int RollDice()
    {
        return Random.Range(1, DiceSides + 1); // Roll dice inclusive of diceSides
    }

    public override void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP < 0) HP = 0; // Ensure HP does not go negative
    }
}
