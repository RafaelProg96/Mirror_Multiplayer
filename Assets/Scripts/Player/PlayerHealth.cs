using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerHealth : NetworkBehaviour
{
	public event Action OnTakeDamage;

	[SerializeField]
	private float m_MaxHealth = 100;
	[SerializeField][SyncVar]
	private float m_CurrentHealth;

	public float MaxHealth
	{
		get
		{
			return m_MaxHealth;
		}
	}

	public float CurrentHealth
	{
		get
		{
			return m_CurrentHealth;
		}
	}

	private void OnEnable()
	{
		OnTakeDamage += CmdDamageTaken;
	}

	private void OnDisable()
	{
		OnTakeDamage -= CmdDamageTaken;
	}

	private void Start()
	{
		m_CurrentHealth = m_MaxHealth;
	}

	public void TakeDamage(float damage)
	{
		float health = m_CurrentHealth - damage;

		if (health <= 0)
		{
			//Jogador morreu
			//Criar um evento para isso
			GetComponent<PlayerMovement>().enabled = false;
		}
		else
		{
			m_CurrentHealth -= damage;
			if (OnTakeDamage != null)
				OnTakeDamage();
		}			
	}

	[Command]
	private void CmdDamageTaken()
	{
		Debug.Log(gameObject.name + " took damage!");
	}
}
