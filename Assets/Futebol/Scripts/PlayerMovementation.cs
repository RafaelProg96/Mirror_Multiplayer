using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementation : MonoBehaviour
{
    private int speed = 10;
    // Player movement speed

    void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0f, Input.GetAxis("Vertical") * Time.deltaTime * speed);
    }
}
