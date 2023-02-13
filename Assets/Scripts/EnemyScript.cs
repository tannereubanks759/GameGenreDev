using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    #region Variables

    [Header("Animations")]
    public Animator animator;
    public string stateParameters = "State";

    public enum enemyStates { WalkingL, WalkingR, Idle, Combat};

    [Header("States")]
    public enemyStates state;
    private enemyStates cashedState;

    [Header("Walk")]
    public float walkingTime = 1f;
    private float walkedTime = 0f;

    [Range(0, 5)]
    public float speed;

    [Header("Idle")]

    private CharacterController controller;

    [Header("combat")]

    public float range = 1f;

    public ParticleSystem sparks;

    private bool inRange = false;

    private Transform target = null;

    #endregion 

    
    void Start()
    {
        controller = GetComponent<CharacterController>();
        GameObject temp;
        temp = GameObject.FindGameObjectWithTag("Player");
        if (temp != null){
            target = temp.transform;
        }
        
        //if (TryGetComponent<CharacterController>(out controller))
        //{
        //    controller.radius = 2f;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        CheckRange();
        if (!inRange)
        {
            Freeze();
        }
        Freeze();
        switch (state)
        {
            case enemyStates.WalkingL:
                WalkingL();
                break;
            case enemyStates.WalkingR:
                WalkingR();
                break;
            case enemyStates.Idle:
                Idle();
                break;
            case enemyStates.Combat:
                Combat();
                break;
        }
        UpdateAnimation();
        
    }
    void WalkingL()
    {
        if (inRange)
        {
            state = enemyStates.Combat;
            walkedTime = 0;
            return;
        }

        walkedTime += Time.deltaTime;

        controller.Move(Vector3.left * speed * Time.deltaTime);
        if(walkedTime >= walkingTime)
        {
            state = enemyStates.WalkingR;
            walkedTime = 0;
        }
        cashedState = state;
    }
    void WalkingR()
    {
        if (inRange)
        {
            state = enemyStates.Combat;
            walkedTime = 0;
            return;
        }

        walkedTime += Time.deltaTime;

        controller.Move(Vector3.right * speed * Time.deltaTime);
        if (walkedTime >= walkingTime)
        {
            state = enemyStates.WalkingL;
            walkedTime = 0;
        }
        cashedState = state;
    }
    void Idle()
    {
        if (inRange)
        {
            state = enemyStates.Combat;
            walkedTime = 0;
            return;
        }
    }
    void Combat()
    {
        if (!inRange)
        {
            state = cashedState;
            return;
        }

    }
    void Freeze()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction, Color.red);
        if(Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
        {
            if(hit.transform == this.transform)
            {
                if (state != enemyStates.Idle)
                {
                    cashedState = state;
                }
                state = enemyStates.Idle;
                return;
            }
        }
        state = cashedState;
        
    }
    void CheckRange()
    {
        if(target == null)
        {
            inRange = false;
            return;
        }
        if((target.position - this.transform.position).magnitude <= range)
        {
            inRange = true;
        }

        inRange = ((target.position - this.transform.position).magnitude <= range);

    }
    void UpdateAnimation()
    {
        animator.SetInteger(stateParameters, (int)state);
    }
    void PlaySparks()
    {
        Debug.Log("spark");
        if(sparks != null)
        {
            sparks.Play();
        }
    }
}
