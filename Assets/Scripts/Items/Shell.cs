using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(NetworkTransform))]
public class Shell : NetworkBehaviour
{
	private Rigidbody m_Rigidbody;
	[SerializeField]
	private float m_ShellSpeed = 100;
	[SerializeField]
	private float m_ShellDamage = 35;
	[SerializeField]
	private float m_ExplosionRange = 5.5f;
	[SerializeField]
	private ShellSpawnManager m_SpawnManager;

	public ShellSpawnManager SpawnManager
	{
		get
		{
			return m_SpawnManager;
		}
		set
		{
			m_SpawnManager = value;
		}
	}

	private void Awake()
	{
		m_Rigidbody = GetComponent<Rigidbody>();
	}

	public void FireShell()
	{
		m_Rigidbody.velocity = transform.forward * m_ShellSpeed;		
	}

	private void ShellDeactivation()
	{
		gameObject.SetActive(false);
		
		transform.rotation = Quaternion.identity;

		m_Rigidbody.velocity = Vector3.zero;		
	}

	private void OnTriggerEnter(Collider other)
	{
		var health = other.GetComponent<PlayerHealth>();

		if(health != null)
		{
			health.TakeDamage(m_ShellDamage);
		}

		m_SpawnManager.UnSpawnObject(gameObject);

		ShellDeactivation();
	}
}
