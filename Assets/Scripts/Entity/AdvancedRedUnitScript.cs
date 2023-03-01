using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedRedUnitScript : RedUnitScript
{
    public enum State {Patrol, Pause, Chase}
    public State state;

    [Header("Pause State")]
    public float pauseLength;
    public float pauseTimer = 0;

    [Header("Player")]
    public float visionRange = 5;
    private UnitScript player;

    public LayerMask visionLayers;
    new void Start()
    {
        health = MaxHP;

        Instantiate(spawnParticles, transform.position, Quaternion.identity);

        controller = GetComponent<CharacterController>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<UnitScript>();
    }
    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position, player.gameObject.transform.position);

        switch (state)
        {
            case State.Patrol:
                Patrol();
                break;
            case State.Pause:
                Pause();
                break;
            case State.Chase:
                Chase();
                break;
        }
    }
    void Patrol()
    {
        if (CanSeePlayer())
        {
            state = State.Chase;
            pauseTimer = 0;
            return;
        }

        if (nextNode == null)
        {
            return;
        }

        controller.Move((nextNode.transform.position - transform.position).normalized * speed * Time.deltaTime);

        if (Vector3.Distance(nextNode.transform.position, transform.position) <= minDistance)
        {
            nextNode = nextNode.GetNext();

            state = State.Pause;
        }
    }
    void Pause()
    {
        if(pauseTimer >= pauseLength)
        {
            pauseTimer = 0;
            state = State.Patrol;
            return;
        }
        pauseTimer += Time.deltaTime;
        
    }
    void Chase()
    {

    }

    bool CanSeePlayer()
    {
        bool inRange = Vector3.Distance(transform.position, player.transform.position) <= visionRange;

        if (inRange)
        {
            if(Physics.Raycast(transform.position, player.transform.position - transform.position, out RaycastHit info, visionRange, visionLayers)){
                return info.transform.tag == ("Player");
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }

    }
}
