using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticExample : MonoBehaviour
{
	private static List<int> lista = new List<int>();

	private static int numero = 0;

	public static void AddObject(int valor)
	{
		lista.Add(valor);
		Debug.Log("Added " + valor + " to the list.");

		numero = valor;

		Debug.Log("Numero: " + numero);
	}
}
