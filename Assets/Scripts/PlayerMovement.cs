using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : NetworkBehaviour
{
    private Rigidbody m_Rigigbody;

    public float movementSpeed = 20f;
    public float turnSpeed = 5.5f;

    private void Awake()
    {
        m_Rigigbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //Verifica se este script está sendo executado no player do mesmo cliente
        if (isLocalPlayer)
        {
            float v = Input.GetAxis("Vertical");
            float h = Input.GetAxis("Horizontal");

            Movement(v);
            Rotation(h);
        }
    }

    void Movement(float input)
    {
        float movement = input * movementSpeed * Time.deltaTime;

        //Vector3 direction = new Vector3(0, 0, movement);

        m_Rigigbody.velocity = transform.forward * movement;
    }

    void Rotation(float input)
    {
        float rotationValue = input * turnSpeed * Time.deltaTime;

        Quaternion rotation = Quaternion.Euler(0, rotationValue, 0);

        m_Rigigbody.MoveRotation(m_Rigigbody.rotation * rotation);
    }
}