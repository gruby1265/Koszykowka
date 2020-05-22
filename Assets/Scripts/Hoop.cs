using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoop : MonoBehaviour
{
    Rigidbody rb;
    RaycastHit hit;
    int layerNumber = 1 << 8; //The Physics.Raycast function takes a bitmask, where each bit determines if a layer will be ignored or not. If all bits in the layerMask are on, we will collide against all colliders.

    Vector3 mousePosFar;
    Vector3 mousePosNear;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        mousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
        mousePosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
    }

    void FixedUpdate()
    {
        Vector3 mousePosF = Camera.main.ScreenToWorldPoint(mousePosFar);
        Vector3 mousePosN = Camera.main.ScreenToWorldPoint(mousePosNear);
        Debug.DrawRay(mousePosN, mousePosF - mousePosN, Color.green);
        if (Physics.Raycast(mousePosN, mousePosF - mousePosN, out hit, 1000f, layerNumber))
        {
            transform.position = new Vector3(hit.point.x, transform.position.y, transform.position.z); // rb.MovePosition();
        }
    }
}