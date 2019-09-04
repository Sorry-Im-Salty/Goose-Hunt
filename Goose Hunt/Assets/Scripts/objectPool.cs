using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectPool : MonoBehaviour
{
	public static objectPool sharedInstance;
	public List<GameObject> pooledObjects;
	public GameObject objectToPool;
	public int amountToPool;


	void Awake()
	{
		sharedInstance = this;
	}

    void Start()
    {
		pooledObjects = new List<GameObject>();
		for (int i = 0; i < amountToPool; i++)
		{
			GameObject obj = Instantiate(objectToPool);
			obj.SetActive(false);
			pooledObjects.Add(obj);
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public GameObject GetPooledObject()
	{
		for (int i = 0; i < pooledObjects.Count; i++)
		{
			if (!pooledObjects[i].activeInHierarchy)
			{
				return pooledObjects[i];
			}
		}
		return null;
	}
}
