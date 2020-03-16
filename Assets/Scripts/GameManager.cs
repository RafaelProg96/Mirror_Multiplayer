using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Prototipo.Multiplayer;

public class GameManager : NetworkManager
{
    public List<PlayerController> players = new List<PlayerController>();

    public static GameManager instance;

    public override void Awake()
    {
        base.Awake();

        if (instance == null && instance != this)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddPlayer(PlayerController playerCon)
    {
        players.Add(playerCon);
    }

    public void RemovePlayer(PlayerController playerCon)
    {
        players.Remove(playerCon);
    }

    public override void OnClientConnect(NetworkConnection conn)
    {
        base.OnClientConnect(conn);

        Debug.Log("OnClientConnect");

        Debug.Log(conn.identity.gameObject.name);

        var playerController = conn.identity.gameObject.GetComponent<PlayerController>();

        AddPlayer(playerController);
    }

    public override void OnServerDisconnect(NetworkConnection conn)
    {
        Debug.Log("OnServerDisconnect");

        Debug.Log(conn.identity.gameObject.name);

        var playerController = conn.identity.gameObject.GetComponent<PlayerController>();

        RemovePlayer(playerController);

        base.OnServerDisconnect(conn);
    }
}
/*
 * public List<PlayerController> players = new List<PlayerController>();

    public static GameManager instance;

    public void Awake()
    {
        //base.Awake();

        if (instance == null && instance != this)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddPlayer(PlayerController playerCon)
    {
        players.Add(playerCon);
    }
*/