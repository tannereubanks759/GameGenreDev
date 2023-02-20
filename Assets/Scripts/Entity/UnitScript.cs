using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour
{
    public int MaxHP = 100;
    
    //unit will always have health
    //_health stores the actual value
    //while health allows us to modify _health through its methods
    private int _health;


    //set the health to its initial maximum value at the beginning of the program
    protected void Start()
    {
        health = MaxHP;
    }
    public int health
    {
        set
        {
            _health = value;
            if (_health <= 0)
            {
                Die();
            }
        }
        get
        {
            return _health;
        }
    }

    //function called when unit dies
    protected virtual void Die()
    {
        Destroy(this.gameObject);
    }

    //funtion tells this unit to receive damage
    public virtual void Damage(int dmg)
    {
        health -= dmg;
    }
}
