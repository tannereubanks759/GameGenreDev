using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitControlScript : MonoBehaviour
{
    public int rightClickDamage = 50;

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(1) && Physics.Raycast(ray, out RaycastHit info, Mathf.Infinity))
        {
            if (info.transform.TryGetComponent<UnitScript>(out UnitScript target))
            {
                target.Damage(rightClickDamage);
            }
        }
    }
}
