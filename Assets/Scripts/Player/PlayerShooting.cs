using UnityEngine;
using Mirror;

public class PlayerShooting : NetworkBehaviour
{
	[SerializeField] private GameObject m_ShellPrefab = null;

	private int maxAmmunition = 4;
	private int currentAmmunition;

	private Rigidbody[] shellPool;
	[SerializeField]
	private Transform shellParent;

	private void Awake()
	{
		shellPool = new Rigidbody[maxAmmunition];

		shellParent = GameController.singleton.ShellParent;
	}

	public override void OnStartLocalPlayer()
	{
		base.OnStartLocalPlayer();

		ObjectPoolSetup();
	}

	private void ObjectPoolSetup()
	{
		for (int i = 0; i < shellPool.Length; i++)
		{
			var shell = Instantiate(m_ShellPrefab, shellParent);

			shellPool[i] = shell.GetComponent<Rigidbody>();

			shellPool[i].gameObject.SetActive(false);
		}
	}
}
