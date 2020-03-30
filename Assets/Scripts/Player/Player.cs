using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player : NetworkBehaviour
{
    [SerializeField]private Camera playerCamera;
    [SerializeField]private GameObject cameraPrefab;
    [SerializeField]private Transform cameraPosition;

    void Start()
    {
        if(!isLocalPlayer)   
        {
            return;
        }

        SetupCamera();
    }

    void SetupCamera()
    {
        var camera = Instantiate(cameraPrefab, cameraPosition);

        camera.transform.rotation = cameraPosition.rotation;

        camera.tag = "MainCamera";

        playerCamera = camera.GetComponent<Camera>();
    }
}
