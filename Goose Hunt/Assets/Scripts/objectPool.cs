using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages gameobjects which are 'deleted' often.
/// </summary>

public class objectPool : MonoBehaviour
{
    /// <summary>
    /// A shared instance which can be accessed from other scripts.
    /// </summary>
	public static objectPool sharedInstance;
    /// <summary>
    /// A list of gameobjects.
    /// </summary>
	public List<GameObject> pooledObjects;
    /// <summary>
    /// Stores the object to be pooled.
    /// </summary>
	public GameObject objectToPool;
    /// <summary>
    /// Stores the amount that will be pooled.
    /// </summary>
	public int amountToPool;


    /// <summary>
    /// Creates a shared Instance of the class.
    /// </summary>
    void Awake()
	{
		sharedInstance = this;
	}

    /// <summary>
    /// Creates a list of objects with the size depending on the amountToPool input.
    /// </summary>
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

    /// <summary>
    /// Returns the pooledObject number.
    /// </summary>
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
