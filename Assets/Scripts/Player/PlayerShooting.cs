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

		spawnManager = GameController.singleton.SpawnManager;
	}

	public override void OnStartLocalPlayer()
	{
		base.OnStartLocalPlayer();

		//ObjectPoolSetup();
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
			shellScript.FireShell();
		}

		StartCoroutine(DisableObject(shell, 5f));
	}

	private IEnumerator DisableObject(GameObject go, float timer)
	{
		yield return new WaitForSeconds(timer);

		spawnManager.UnSpawnObject(go);

		NetworkServer.UnSpawn(go);
	}

	private void ObjectPoolSetup()
	{
		for (int i = 0; i < shellPool.Length; i++)
		{
			var shell = Instantiate(m_ShellPrefab, spawnManager.poolTransform);

			shellPool[i] = shell.GetComponent<Rigidbody>();

			shellPool[i].gameObject.SetActive(false);
		}
	}
}
