using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUi : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private Button[] weaponButtons;

    private void SelectPickaxe()
    {
        //playerManager.ChooseWeapon(int index);
    }
}
