using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace Prototipo.Multiplayer
{
    public class PlayerController : NetworkBehaviour
    {
        private SpawnManager spawnManager;        

        private void Start()
        {
            spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        }

        private void Update()
        {
            if (!isLocalPlayer)
                return;

            if(Input.GetKeyDown(KeyCode.Space))
            {
                CmdFire();
            }
        }

        [Command]
        void CmdFire()
        {
            // Set up coin on server
            var coin = spawnManager.GetFromPool(transform.position + transform.forward);
            if(coin = null)
            {
                Debug.Log("Cannot fire");
            }
            else
            {
                coin.GetComponent<Rigidbody>().velocity = transform.forward * 4;

                // spawn coin on client, custom spawn handler is called
                NetworkServer.Spawn(coin, spawnManager.assetId);

                // when the coin is destroyed on the server, it is automatically destroyed on clients
                StartCoroutine(Destroy(coin, 2.0f));
            }            
        }

        public IEnumerator Destroy(GameObject go, float timer)
        {
            yield return new WaitForSeconds(timer);
            spawnManager.UnSpawnObject(go);
            NetworkServer.UnSpawn(go);
        }
    }
}