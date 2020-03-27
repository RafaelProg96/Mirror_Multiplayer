using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace Prototipo.Multiplayer
{
    public class PlayerController : NetworkBehaviour
    {
        private Renderer m_Renderer;            //Referência para o componente de renderização do objeto
        private NetworkIdentity m_Identity;     //Referência para o componente "NetworkIdentity"
        [SyncVar(hook = "SetColor")]
        private Color playerColor;

		private Animator m_Animator;

		public Color PlayerColor
		{
			set
			{
				playerColor = value;
			}
		}

        private Material cachedMaterial;

        private void Awake()
        {
            m_Renderer = GetComponent<Renderer>();
            m_Identity = GetComponent<NetworkIdentity>();
			m_Animator = GetComponent<Animator>();
        }

		private void Update()
		{
			if (!isLocalPlayer)
				return;

			if(Input.GetKeyDown(KeyCode.Space))
			{
				m_Animator.SetTrigger("SwitchLight");
			}
		}

		//Função chamada ao Spawn de um cliente na cena
		public override void OnStartLocalPlayer()
        {
            base.OnStartLocalPlayer();
            //Criando uma variável do tipo Color e recebendo o retorno da função RandomColor()
            playerColor = RandomColor();
            //Chamar a função com atributo Command, que será executada no servidor
            //CmdChangeColor();
        }
		/*
        //Função que será invocada no objeto do cliente e executada somente no servidor
        [Command]
        private void CmdChangeColor()
        {
            //Chama a função SetColor, passando como parâmetro a variável "playerColor"
            SetColor(playerColor);
            //Invoca a função Rpc no servidor, para executar em todos os clientes
            RpcChangeColor(playerColor);
        }

        //Função que será invocada no objeto do servidor e executada em todos os clientes que possuírem essa classe
        [ClientRpc]
        private void RpcChangeColor(Color _color)
        {
            //Chama a função SetColor em todos objetos que possuírem a mesma
            SetColor(_color);
        }
		*/
        //Função pública que faz o sorteio e alteração da variável playerColor
        public void ChangeColor(Color _color)
        {
			//playerColor = RandomColor();
			playerColor = _color;
        }

        private void SetColor(Color oldColor, Color newColor)
        {
            if (cachedMaterial == null)
                cachedMaterial = m_Renderer.material;
            //Acessar o material que está associado ao renderizador, e alterar a cor dele
            cachedMaterial.color = newColor;
        }

        //Função que cria uma cor com valores RGB aleatórios
        private Color RandomColor()
        {
            Color randomColor;

            randomColor = new Color
                (
                    Random.Range(.0f, 1f), Random.Range(.0f, 1f), Random.Range(.0f, 1f)
                );

            return randomColor;
        }

        private void OnDestroy()
        {
            Destroy(cachedMaterial);
        }
    }

}