using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
	[SerializeField] private int valor;
	
	// Start is called before the first frame update
    void Start()
    {		
		StaticExample.AddObject(valor);
	}    
}
