using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by Connor Li
public class Spawner : MonoBehaviour
{
	int m_goose;
	float m_timer;
	public float m_spawnTimer = 5.0f;
	public static int m_objects = 10;
	public Object m_fly;
	GameObject[] m_ob = new GameObject[m_objects];
	public Transform m_parent;
	bool MouseOver = false;
    // Start is called before the first frame update
    void Start()
    {
		//Creates Goose Spawn Pool 
		for (int i = 0; i < m_objects; ++i)
		{
			m_ob[i] = Instantiate(m_fly, m_parent) as GameObject;
			m_ob[i].SetActive(false);
		}
	}

    // Update is called once per frame
    void Update()
    {
		m_timer += Time.deltaTime;
		//Spawn
		if (m_timer >= m_spawnTimer)
		{
			//Checks the amount of objects
			if(m_goose == m_objects)
			{
				m_goose = 0;
			}
			//Checks if the object is inactive
			if (m_ob[m_goose].activeInHierarchy == false)
			{
				m_ob[m_goose].SetActive(true);
				++m_goose;
			}

			m_timer = 0;
		}
    }

	void OnMouseOver()
	{
		MouseOver = true;
	}
	void OnMouseExit()
	{
		MouseOver = false;
	}
}
