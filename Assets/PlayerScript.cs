using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : UnitScript
{
    public CharacterController controller;
    public float speed;

    new void Start()
    {
        health = MaxHP;
        controller = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 movementVector = Vector3.zero;
        movementVector.x = -Input.GetAxis("Horizontal");
        movementVector.z = -Input.GetAxis("Vertical");
        controller.Move(movementVector * speed * Time.deltaTime);
    }
}
