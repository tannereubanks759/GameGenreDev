using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    #region Variables
    public enum enemyStates { WalkingL, WalkingR, Idle };

    [Header("States")]
    public enemyStates state;

    [Header("Walk")]
    public float walkingTime = 1f;
    private float walkedTime = 0f;

    [Range(0, 5)]
    public float speed;

    [Header("Idle")]


    private CharacterController controller;
    #endregion 
    void Start()
    {
        controller = GetComponent<CharacterController>();
        //if (TryGetComponent<CharacterController>(out controller))
        //{
        //    controller.radius = 2f;
        //}
    }

    // Update is called once per frame
    void Update()
    {
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
        }
        
    }
    void WalkingL()
    {
        walkedTime += Time.deltaTime;

        controller.Move(Vector3.left * speed * Time.deltaTime);
        if(walkedTime >= walkingTime)
        {
            state = enemyStates.WalkingR;
            walkedTime = 0;
        }
    }
    void WalkingR()
    {
        walkedTime += Time.deltaTime;

        controller.Move(Vector3.right * speed * Time.deltaTime);
        if (walkedTime >= walkingTime)
        {
            state = enemyStates.WalkingL;
            walkedTime = 0;
        }
    }
    void Idle()
    {

    }
    void Freeze()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction, Color.red);
        if(Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
        {
            if(hit.transform == this.transform)
            {
                state = enemyStates.Idle;
                return;
            }
        }
        state = enemyStates.WalkingR;
    }
}
