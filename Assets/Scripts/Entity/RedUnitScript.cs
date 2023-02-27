using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedUnitScript : UnitScript
{
    //the node we will follow
    public NodeScript nextNode;
    public CharacterController controller;
    public float speed;
    public float minDistance;

    public ParticleSystem spawnParticles;

    // Start is called before the first frame update
    new void Start()
    {
        health = MaxHP;

        Instantiate(spawnParticles, transform.position, Quaternion.identity);

        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if(nextNode == null)
        {
            return;
        }

        controller.Move((nextNode.transform.position - transform.position).normalized * speed * Time.deltaTime);

        if(Vector3.Distance(nextNode.transform.position,transform.position) <= minDistance)
        {
            nextNode = nextNode.GetNext();
        }
    }
}
