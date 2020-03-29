using System.Collections;
using UnityEngine;
using Mirror;

public class PlayerShooting : NetworkBehaviour
{
	[SerializeField] private GameObject m_ShellPrefab = null;
	[SerializeField] private Transform m_ShellExit = null;

	private int maxAmmunition = 4;
	private int currentAmmunition;

	private Rigidbody[] shellPool;	
	private SpawnManager spawnManager;

	private void Awake()
	{
		shellPool = new Rigidbody[maxAmmunition];

		spawnManager = GetComponent<SpawnManager>();
	}	

	private void Update()
	{
		if (!isLocalPlayer)
			return;

		if(Input.GetKeyDown(KeyCode.Space))
		{
			CmdShoot();
		}
	}

	[Command]
	private void CmdShoot()
	{
		var shell = spawnManager.GetFromPool(m_ShellExit.position);

		shell.transform.rotation = m_ShellExit.rotation;

		NetworkServer.Spawn(shell, spawnManager.assetId);

		var shellScript = shell.GetComponent<Shell>();

		if (shellScript != null)
		{
			shellScript.FireShell(this);
		}		
	}

	public void ReturnToPool(GameObject go)
	{
		spawnManager.UnSpawnObject(go);

		NetworkServer.UnSpawn(go);
	}

	private IEnumerator DisableObject(GameObject go, float timer)
	{
		yield return new WaitForSeconds(timer);

		spawnManager.UnSpawnObject(go);

		NetworkServer.UnSpawn(go);
	}	
}
