using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

[RequireComponent(typeof(Rigidbody))]
public class Shell : NetworkBehaviour
{
	private Rigidbody m_Rigidbody;
	[SerializeField]
	private float m_ShellSpeed = 100;
	[SerializeField]
	private float m_ShellDamage = 40;
	[SerializeField]
	private float m_ExplosionRange = 5.5f;

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

		transform.position = Vector3.zero;
		m_Rigidbody.velocity = Vector3.zero;
		m_Rigidbody.Sleep();
	}
}
