using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BlueUnitScript : UnitScript
{ 
    public GameObject targetObject;

    private NavMeshAgent agent;

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

    private void Update()
    {
        if(agent == null)
        {
            return;
        }
        agent.SetDestination(targetObject.transform.position);

        
    }
    private new void Start()
    {
        health = MaxHP;

        agent = GetComponent<NavMeshAgent>();
    }
}
