using UnityEngine;
public class Weapon : MonoBehaviour
{
    [SerializeField] private string weaponName; // Name of the weapon
    [SerializeField] private int diceSides; // Number of sides on the weapon's dice

    public string Name => weaponName;
    public int DiceSides => diceSides;

    private CombatSystem combatSystem;

    [System.Obsolete]
    private void Start()
    {
        combatSystem = FindObjectOfType<CombatSystem>();
        if (combatSystem == null)
        {
            Debug.LogError("CombatSystem not found in the scene!");
        }
    }

    public void OnWeaponClicked()
    {
        if (combatSystem == null)
        {
            Debug.LogError("CombatSystem not initialized!");
            return;
        }

        Debug.Log($"Weapon selected: {weaponName}");
        combatSystem.PlayerSelectWeapon(this); // Ensures that the player doesn't select one weapon but uses another
    }
}