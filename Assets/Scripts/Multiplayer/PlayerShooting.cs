using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerShooting : NetworkBehaviour
{
    [SerializeField]
    private GameObject shotPrefab;      //Referência para o objeto o a ser instanciado

    private void Start()
    {
        //Acessar o primeiro prefab da lista de spawn do NetworkManager
        shotPrefab = NetworkManager.singleton.spawnPrefabs[0];
    }

    private void Update()
    {
        //Se não for o local player, sair da função
        if (!isLocalPlayer)
            return;
        //Se apertar a tecla espaço...
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //Invocar a função "CmdShoot"
            CmdShoot();
        }
    }

    [Command]
    void CmdShoot()
    {
        //Cria uma variável que vai receber a instância do prefab a ser gerado nos clientes
        var instancia = Instantiate(shotPrefab, transform.position, transform.rotation) as GameObject;
        //Chama a função Spawn que cria os objetos em todos os clientes
        NetworkServer.Spawn(instancia, gameObject);
        //Acessa o Rigidbody do objeto criado e adiciona uma velocidade inicial
        instancia.GetComponent<Rigidbody>().velocity = transform.forward * 25;

        StartCoroutine(Destroy(instancia, 5f));
    }

    //Coroutina para destruir o objeto após um tempo determinado
    public IEnumerator Destroy(GameObject go, float timer)
    {
        yield return new WaitForSeconds(timer);
        //Função executada no servidor para destruir um objeto
        //Pode ser usada a função UnSpawn(), que NÃO destrói o objeto, permitindo reutilização
        NetworkServer.Destroy(go);

        Destroy(go);
    }
}