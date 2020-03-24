using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Mirror;

namespace Prototipo
{
	public class NetworkManagerLobby : NetworkManager
	{
		[Space(20f)]
		[Scene] [SerializeField] private string menuScene = string.Empty;

		[Header("Room")]
		[SerializeField] private NetworkLobbyPlayer lobbyPlayerPrefab = null;

		public static event Action OnClientConnected;
		public static event Action OnClientDisconnected;

		[SerializeField]
		private static List<PlayerController> players = new List<PlayerController>();

		public static void AddPlayer(PlayerController playerController)
		{
			players.Add(playerController);
			Debug.Log("Added " + playerController.name);
		}

		public override void OnClientConnect(NetworkConnection conn)
		{
			base.OnClientConnect(conn);

			if(OnClientConnected != null)
			{
				OnClientConnected();
				Debug.Log("OnClientConnected");
			}
		}

		public override void OnClientDisconnect(NetworkConnection conn)
		{
			base.OnClientDisconnect(conn);

			if(OnClientDisconnected != null)
			{
				OnClientDisconnected();
				Debug.Log("OnClientDisconnected");
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
			//base.OnServerAddPlayer(conn);

			if(SceneManager.GetActiveScene().name == menuScene)
			{
				NetworkLobbyPlayer networkLobbyPlayer = Instantiate(lobbyPlayerPrefab);

				NetworkServer.AddPlayerForConnection(conn, networkLobbyPlayer.gameObject);
			}
		}
	}
}