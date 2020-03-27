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
		private Animator m_Animator;            //Referência para o componente "Animator"

		private Material cachedMaterial;		//Referência para alocar temporariamente um material.

		//Variável do tipo Color que possui o atributo "SyncVar".
		//Essa variável terá seu valor sincronizado com o servidor e todos os clientes conectados.
		//Dentro do atributo temos um hook, que invoca a função do parâmetro, no momento em que a variável tem seu valor alterado.
		[SyncVar(hook = "SetColor")] private Color playerColor;		
		
		//Propriedade write-only para o campo "playerColor"
		public Color PlayerColor
		{
			set
			{
				playerColor = value;
			}
		}        

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

			if(Input.GetKeyDown(KeyCode.T))
			{
				playerColor = RandomColor();
			}
		}

		//Função chamada ao Spawn de um cliente na cena
		public override void OnStartLocalPlayer()
        {
            base.OnStartLocalPlayer();
            //Atribuir a "playerColor" o retorno da função RandomColor()
            playerColor = RandomColor();
        }
		
        //Função pública que faz o sorteio e alteração da variável playerColor
        public void ChangeColor(Color _color)
        {
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