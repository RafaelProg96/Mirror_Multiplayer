using UnityEngine;

public class GameController : MonoBehaviour
{
	[SerializeField]
	private Transform m_ShellParent;

	public static GameController singleton { get; private set; }

	public Transform ShellParent
	{
		get { return m_ShellParent; }
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
