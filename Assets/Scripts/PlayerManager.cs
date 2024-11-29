using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private List<Weapon> _inventory = new List<Weapon>();
    private Weapon _currentWeapon;
    public Weapon CurrentWeapon => _currentWeapon;
    public int HP { get; private set; } = 100;
    void Start()
    {
        _inventory.Add(new Weapon("Pickaxe", 6)); // Rolls 1-6
        _inventory.Add(new Weapon("Machete", 8)); // Rolls 1-8
        _inventory.Add(new Weapon("Flamethrower", 10)); // Rolls 1-10
    }
    private void OnEnable()
    {
        if (_inventory.Count > 0)
        {
            _currentWeapon = _inventory[0];
            Debug.Log($"Default weapon set to: {_currentWeapon.Name}");
        }
        else
        {
            Debug.Log("No weapons available in the inventory!");
        }
    }

    public void ChooseWeapon(int index)
    {
        if (index >= 0 && index < _inventory.Count)
        {
            _currentWeapon = _inventory[index];
            Debug.Log($"Weapon selected: {_currentWeapon.Name}");
        }
        else
        {
            Debug.LogError("Invalid weapon index selected!");
        }
    }

    public int RollDice()
    {
        return _currentWeapon != null
            ? Random.Range(1, _currentWeapon.DiceSides + 1)
            : throw new System.InvalidOperationException("No weapon equipped to roll dice.");
    }

    public void TakeDamage(int damage)
    {
        HP = Mathf.Max(HP - damage, 0);
        Debug.Log($"Player took {damage} damage. Current HP: {HP}");
    }
}