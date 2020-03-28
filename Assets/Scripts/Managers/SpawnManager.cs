using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class SpawnManager : MonoBehaviour
{
	[SerializeField]
	private int m_poolSize = 4;
	[SerializeField]
	private GameObject m_Prefab = null;
	[SerializeField]
	private GameObject[] m_Pool = null;

	public System.Guid assetId { get; set; }

	public delegate GameObject SpawnDelegate(Vector3 position, System.Guid assetId);

	public delegate void UnSpawnDelegate(GameObject spawnedObject);

	public Transform poolTransform;

	private void Start()
	{
		assetId = m_Prefab.GetComponent<NetworkIdentity>().assetId;
		m_Pool = new GameObject[m_poolSize];

		for (int i = 0; i < m_poolSize; i++)
		{
			m_Pool[i] = Instantiate(m_Prefab, poolTransform);
			m_Pool[i].name = m_Prefab.name + i;
			m_Pool[i].SetActive(false);
		}

		ClientScene.RegisterSpawnHandler(assetId, SpawnObject, UnSpawnObject);
	}

	public GameObject GetFromPool(Vector3 _position)
	{
		foreach(var obj in m_Pool)
		{
			if(!obj.activeInHierarchy)
			{
				obj.transform.parent = null;
				obj.transform.position = _position;				
				obj.SetActive(true);
				return obj;
			}
		}

		return null;
	}

	public GameObject SpawnObject(Vector3 _position, System.Guid _assetId)
	{
		return GetFromPool(_position);
	}

	public void UnSpawnObject(GameObject spawnedObject)
	{
		spawnedObject.SetActive(false);
	}
}
