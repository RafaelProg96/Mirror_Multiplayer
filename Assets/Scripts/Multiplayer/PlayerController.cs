using UnityEngine;
using Prototipo;
using Mirror;

public class PlayerController : NetworkBehaviour
{
    [SerializeField]
    private GameObject cameraPrefab;
    [SerializeField]
    private CameraController playerCamera;
    [SerializeField]
    private Transform cameraPosition;

    public override void OnStartClient()
    {
        base.OnStartClient();

        Debug.Log("OnStartClient");

        NetworkManagerLobby.AddPlayer(this);        
    }

    private void Start()
    {
        if (!isLocalPlayer)
            return;

        SetupCamera();
    }

    void SetupCamera()
    {
        var camera = Instantiate(cameraPrefab, cameraPosition);

        camera.transform.rotation = cameraPosition.rotation;

        camera.GetComponent<Camera>().tag = "MainCamera";

        playerCamera = camera.GetComponent<CameraController>();

        playerCamera.Owner = this;
    }

	void DisplayConnectedPlayer()
	{
		Debug.Log(gameObject.name);
	}	
}