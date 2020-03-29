using UnityEngine;
using Mirror;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(NetworkTransform))]
public class PlayerMovement : NetworkBehaviour //Componentes utilizados na rede devem herdar de NetworkBehaviour, onde se encontrar as variáveis e CallBacks
{
	private Rigidbody m_Rigigbody;

	public float movementSpeed = 8.5f;   //Velocidade de movimento
	public float turnSpeed = 18.75f;        //Velocidade de rotação

	private float horizontalInput = 0f;
	private float verticalInput = 0f;

	private void Awake()
	{
		//Acessa o componente Rigidbody e armazena-o na referência "m_Rigidbody"
		m_Rigigbody = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		//Verifica se este script está sendo executado no player do mesmo cliente
		if (isLocalPlayer)
		{
			//Lê os valores de input dos eixos y e x, respectivamente
			verticalInput = Input.GetAxis("Vertical");
			horizontalInput = Input.GetAxis("Horizontal");		
		}
	}

	private void FixedUpdate()
	{
		if(isLocalPlayer)
		{
			Movement(verticalInput);
			Rotation(horizontalInput);
		}
	}

	void Movement(float input)
	{
		Vector3 movement = transform.forward * input * movementSpeed * Time.fixedDeltaTime;

		m_Rigigbody.MovePosition(m_Rigigbody.position + movement);
	}

	void Rotation(float input)
	{
		float rotationValue = input * turnSpeed * Time.deltaTime;

		Quaternion rotation = Quaternion.Euler(0, rotationValue, 0);

		m_Rigigbody.MoveRotation(m_Rigigbody.rotation * rotation);
	}

	private void OnDisable()
	{
		DisableMovement();
	}

	public void DisableMovement()
	{
		m_Rigigbody.velocity = Vector3.zero;
	}
}