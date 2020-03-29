using UnityEngine;

public class GameController : MonoBehaviour
{		
	public static GameController singleton { get; private set; }	

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
