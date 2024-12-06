using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Decomposer : MonoBehaviour
{
    [SerializeField] public string Name;
    [SerializeField] public int HP;
    [SerializeField] public int DiceSides;
    [SerializeField] public Sprite uiImage;

    // Public properties to access private serialized fields
    public Sprite GetUIImage()
    {
        return uiImage;
    }

    public virtual int RollDice()
    {
        return Random.Range(1, DiceSides + 1); // Roll dice inclusive of diceSides
    }

    public virtual void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP < 0) HP = 0; // Ensure HP does not go negative
    }
}