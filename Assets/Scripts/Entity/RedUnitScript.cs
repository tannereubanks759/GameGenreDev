using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedUnitScript : UnitScript
{
    public ParticleSystem spawnParticles;

    // Start is called before the first frame update
    new void Start()
    {
        health = MaxHP;

        Instantiate(spawnParticles, transform.position, Quaternion.identity);

    }

    
}
