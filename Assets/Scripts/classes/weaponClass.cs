using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class weaponClass
{
    //the prefab will spawn when the weapon in selected
    public Transform weaponPrefab;
    public GameObject weaponPivot;

    //the key will select the weapon
    public KeyCode weaponKey;
    //weapon name
    public string name;

    private GameObject spawnedWeapon;
    public bool KeyPress(KeyCode input)
    {
        return input == weaponKey;
    }
    public void Select()
    {
        spawnedWeapon = MonoBehaviour.Instantiate(weaponPrefab, weaponPivot.transform.position, Quaternion.identity, weaponPivot.transform).gameObject;
        Debug.Log("Selected " + name);
    }
    public void Deselect()
    {
        Debug.Log("Deselected " + name);
        if(spawnedWeapon != null)
        {
            MonoBehaviour.Destroy(spawnedWeapon);
        }
    }
}
 