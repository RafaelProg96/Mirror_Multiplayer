using UnityEngine;

public class GameController : MonoBehaviour
{	
	[SerializeField]
	private SpawnManager m_SpawnManager;

	public static GameController singleton { get; private set; }	

	public SpawnManager SpawnManager
	{
		get
		{
			return m_SpawnManager;
		}
	}


	private void Awake()
	{
		SingletonSetup();
	}

	void SingletonSetup()
	{
		if(singleton != this && singleton == null)
		{
			singleton = this;
			DontDestroyOnLoad(this);
		}
		else
		{
			Debug.LogWarning("Já existe uma instância da classe GameController");
			Destroy(this.gameObject);
		}
	}
}
