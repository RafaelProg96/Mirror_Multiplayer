using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

public class LobbyManager : NetworkManager
{
	public static event Action OnClientConnected;
	public static event Action OnClientDisconnected;

	[Scene][SerializeField] private string menuScene = string.Empty;

	[SerializeField] private GameObject lobbyPlayerPrefab = null;

	public override void OnClientConnect(NetworkConnection conn)
	{
		base.OnClientConnect(conn);

		if(OnClientConnected != null)
		{
			OnClientConnected();
		}
	}

	public override void OnClientDisconnect(NetworkConnection conn)
	{
		base.OnClientDisconnect(conn);

		if(OnClientDisconnected != null)
		{
			OnClientDisconnected();
		}
	}

	public override void OnServerConnect(NetworkConnection conn)
	{
		if(numPlayers >= maxConnections)
		{
			conn.Disconnect();
			return;
		}
	}

	public override void OnServerAddPlayer(NetworkConnection conn)
	{

		if(SceneManager.GetActiveScene().name == menuScene)
		{
			var lobbyPlayer = Instantiate(lobbyPlayerPrefab);

			NetworkServer.AddPlayerForConnection(conn, lobbyPlayer);
		}
	}
}
