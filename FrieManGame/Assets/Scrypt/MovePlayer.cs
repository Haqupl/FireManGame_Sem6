﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    public float speed;
    public LayerMask mask;

    private Rigidbody rb;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputZ = Input.GetAxisRaw("Vertical");

        Move(inputX, inputZ);

        Ray rayMouse = Camera.main.ScreenPointToRay(Input.mousePosition);
        Rotation(rayMouse);
    }

    private void Move(float inputX, float inputZ)
    {
        Vector3 movement = new Vector3();
        movement.Set(inputX, 0f, inputZ);
        //movement.y = 0;
        movement = movement.normalized * speed * Time.deltaTime;

        rb.MovePosition(rb.position + movement);

    }

    private void Rotation(Ray ray)
    {
        RaycastHit hit;
        if (Physics.Raycast(ray,out hit ,100f,mask))
        {
            Vector3 distatnce = hit.point - rb.position;
            distatnce.y = 0;

            Quaternion rot = Quaternion.LookRotation(distatnce);
          
            rb.MoveRotation(rot);
        }
    }

   



}