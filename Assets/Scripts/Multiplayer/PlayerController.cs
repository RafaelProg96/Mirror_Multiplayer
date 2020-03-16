using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Prototipo;
using Mirror;

public class PlayerController : NetworkBehaviour
{
	public override void OnStartClient()
	{
		base.OnStartClient();

		Prototipo.NetworkManagerLobby.AddPlayer(this);
	}

	private void OnEnable()
	{
		Prototipo.NetworkManagerLobby.OnClientConnected += DisplayConnectedPlayer;
	}

	void DisplayConnectedPlayer()
	{
		Debug.Log(this.gameObject.name);
	}

	private void OnDisable()
	{
		Prototipo.NetworkManagerLobby.OnClientConnected -= DisplayConnectedPlayer;
	}
}
