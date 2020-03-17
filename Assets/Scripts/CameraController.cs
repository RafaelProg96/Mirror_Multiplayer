using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private PlayerController owner;

    public PlayerController Owner
    {
        get
        {
            return owner;
        }
        set
        {
            owner = value;
            Setup();
        }
    }

    private Transform target;

    private void Setup()
    {
        if(Owner != null)
        {
            target = Owner.transform;
        }
    }    
}
