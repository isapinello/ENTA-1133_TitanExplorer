using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUi : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private Button[] weaponButtons;

    private void Start()
    {
        for (int i = 0; i < weaponButtons.Length; i++)
        {
            int index = i; // Local copy for closure
            weaponButtons[i].onClick.AddListener(() => SelectWeapon(index));
        }
    }

    public void SelectWeapon(int weaponIndex)
    {
        playerManager.ChooseWeapon(weaponIndex);
    }
}
