using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform Target;

    public float rotSpeed;

    public float minXAngle;
    public float maxXAngle;

    private bool rotating;
    private Vector3 mousePos;
    private GameObject pivot;
    private float EulerX;
    // Start is called before the first frame update
    void Start()
    {
        mousePos = Input.mousePosition;

        if(pivot == null)
        {

            pivot = new GameObject();
            pivot.transform.position = Target.position;

            EulerX = pivot.transform.localEulerAngles.x;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            rotating = true;
        }
        else if (Input.GetButtonUp("Fire2"))
        {
            rotating = false;
        }
        if (rotating)
        {
            Vector2 mouseMovement = Input.mousePosition - mousePos;

            pivot.transform.position = Target.position;
            this.transform.parent = pivot.transform;

            pivot.transform.Rotate(pivot.transform.up, rotSpeed * Time.deltaTime * mouseMovement.x, Space.Self);
            //pivot.transform.Rotate(-Vector3.right, rotSpeed * Time.deltaTime * mouseMovement.y);

            EulerX = EulerX + (rotSpeed * Time.deltaTime * -mouseMovement.y);


            //pivot.transform.localEulerAngles = new Vector3(Mathf.Clamp(pivot.transform.localEulerAngles.x, -90,90) , pivot.transform.localEulerAngles.y, pivot.transform.localEulerAngles.z);
            pivot.transform.localRotation = Quaternion.Euler(Mathf.Clamp(EulerX, minXAngle, maxXAngle), pivot.transform.localEulerAngles.y, 0);
        }


        mousePos = Input.mousePosition;
    }
}
