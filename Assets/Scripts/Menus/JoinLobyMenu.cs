using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Prototipo;

public class JoinLobyMenu : MonoBehaviour
{
	[SerializeField]
	private NetworkManagerLobby networkManager = null;

	[Header("User Interface")]
	[SerializeField]
	private GameObject landingPagePanel = null;
	[SerializeField]
	private InputField ipAdressInputField = null;
	[SerializeField]
	private Button joinButton = null;

	private void OnEnable()
	{
		NetworkManagerLobby.OnClientConnected += HandleClientConnect;
		NetworkManagerLobby.OnClientDisconnected += HandleClientDisconnect;
	}

	private void OnDisable()
	{
		NetworkManagerLobby.OnClientConnected -= HandleClientConnect;
		NetworkManagerLobby.OnClientDisconnected -= HandleClientDisconnect;
	}

	public void JoinLobby()
	{
		string ipAdress = ipAdressInputField.text;

		if(string.IsNullOrEmpty(ipAdress))
		{
			Debug.Log("Invalid IP Adress.");
			return;
		}

		networkManager.networkAddress = ipAdress;
		networkManager.StartClient();

		joinButton.interactable = false;
	}

	private void HandleClientConnect()
	{
		joinButton.interactable = true;

		gameObject.SetActive(false);
		landingPagePanel.SetActive(false);
	}

	private void HandleClientDisconnect()
	{
		joinButton.interactable = true;
	}
}
