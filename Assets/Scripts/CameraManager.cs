using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private static List<CameraController> sceneCameras = new List<CameraController>();

    public static void AddCameraToList(CameraController camera)
    {
        sceneCameras.Add(camera);
    }

    public static bool GetPlayerCamera(PlayerController player)
    {
        CameraController camera = null;

        bool found = false;

        for (int i = 0; i < sceneCameras.Count; i++)
        {
            if (sceneCameras[i].Owner == player)
            {
                camera = sceneCameras[i];

                found = true;
            }            
        }

        return found;
    }
}
