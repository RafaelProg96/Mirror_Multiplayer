using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Prototipo;
using Mirror;

public class MainMenu : MonoBehaviour
{
	[SerializeField]
	private NetworkManagerLobby lobbyManager = null;

	[Header("UI")]
	[SerializeField]
	private GameObject connectionPanel = null;

	public void HostLobby()
	{
		lobbyManager.StartHost();

		connectionPanel.SetActive(false);
	}    
}
