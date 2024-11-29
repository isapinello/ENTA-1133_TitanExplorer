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
    [SerializeField] public string Name { get; private set; }
    [SerializeField] public int DiceSides { get; private set; }

    public Weapon(string name, int diceSides)
    {
        Name = name;
        DiceSides = diceSides;
    }
}