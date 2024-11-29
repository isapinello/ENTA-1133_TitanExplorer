using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decomposer : MonoBehaviour
{
    public string Name { get; protected set; }
    public int HP { get; protected set; }
    public int DiceSides { get; protected set; }

    protected Decomposer(string name, int hp, int diceSides)
    {
        Name = name;
        HP = hp;
        DiceSides = diceSides;
    }

    public int RollDice()
    {
        return Random.Range(1, DiceSides + 1); // Roll dice inclusive of DiceSides
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP < 0) HP = 0;
    }

    // Derived classes for specific enemy types
    public class SmallLarvae : Decomposer
    {
        public SmallLarvae() : base("Small Larvae", 30, 10) { }
    }

    public class RoundWorm : Decomposer
    {
        public RoundWorm() : base("Round Worm", 50, 12) { }
    }

    public class BoneCrusher : Decomposer
    {
        public BoneCrusher() : base("Bone Crusher", 70, 15) { }
    }
}
