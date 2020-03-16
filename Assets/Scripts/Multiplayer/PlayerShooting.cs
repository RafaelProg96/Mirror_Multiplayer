using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerShooting : NetworkBehaviour
{
    [SerializeField]
    GameObject projectilePrefab;

    private void Start()
    {
        projectilePrefab = NetworkManager.singleton.spawnPrefabs[0].gameObject;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    //[Command]
    void Shoot()
    {

    }
}



/*
    GameObject projectilePrefab;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    //[Command]
    void Shoot()
    {

    }
*/
