using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponSelection : MonoBehaviour
{
    
    public weaponClass[] weapons = new weaponClass[0];

    public int selectedWeapon = 0;


    // Start is called before the first frame update
    void Start()
    {
        if(weapons.Length > 0)
        {
            weapons[0].Select();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        WeaponSelection();
    }

    //determines if the weapon should be selected based on player input
    void WeaponSelection()
    {
        //for each weapon in the array
        for(int i = 0; i < weapons.Length; i++)
        {
            weaponClass temp = weapons[i];
            if (i != selectedWeapon && Input.GetKeyDown(temp.weaponKey))
            {
                //select the weapon
                temp.Select();
                //deselect current weapon
                weapons[selectedWeapon].Deselect();
                //the selected weapon is assigned to temp
                selectedWeapon = i;
                return;
            }
        }
    }
}
