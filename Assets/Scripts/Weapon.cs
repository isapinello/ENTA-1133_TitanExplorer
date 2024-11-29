using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class Weapon : MonoBehaviour
{
    public string Name { get; private set; }
    public int DiceSides { get; private set; }

    public Weapon(string name, int diceSides)
    {
        Name = name;
        DiceSides = diceSides;
    }
}