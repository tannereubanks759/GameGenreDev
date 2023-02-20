using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueUnitScript : UnitScript
{
    public ParticleSystem hitParticle;
    public Transform splitEnemies;
    public override void Damage(int dmg)
    {
        Debug.Log("Blue Damage");
        health -= dmg;
        Instantiate(hitParticle, transform.position, Quaternion.identity);
    }
    protected override void Die()
    {
        Instantiate(splitEnemies, transform.position, Quaternion.identity);
        Instantiate(splitEnemies, transform.position, Quaternion.identity);

        Destroy(this.gameObject);
    }
}
