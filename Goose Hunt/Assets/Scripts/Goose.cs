using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by Connor Li
public class Goose : MonoBehaviour
{
	float m_timer;
	public float m_secondsActive;
	public float m_xVelocityMin = 10.0f;
	public float m_xVelocityMax = 20.0f;
	public float m_yVelocity = 20.0f;
	bool MouseOver = false;
	Transform m_Spawner;
	Collider m_Collider;
	Rigidbody m_rb;

    // Start is called before the first frame update
    void Awake()
    {
		m_Spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Transform>();
		m_rb = gameObject.GetComponent<Rigidbody>();
		m_Collider = gameObject.GetComponent<Collider>();
		m_rb.velocity = new Vector3(Random.Range(m_xVelocityMin, m_xVelocityMax), m_yVelocity, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
		m_timer += Time.deltaTime;
		//Resets the goose
		if (m_timer >= 5.0f)
		{
			gameObject.SetActive(false);
			gameObject.transform.position = GetComponentInParent<Transform>().position;
			m_rb.velocity = new Vector3(Random.Range(m_xVelocityMin, m_xVelocityMax), m_yVelocity, 0.0f);
			m_timer = 0.0f;
		}
    }

	private void OnCollisionEnter(Collision collision)
	{
		//Checks if the collision is with another goose
		if (collision.gameObject.tag == "Goose")
		{
			Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), m_Collider);
		}
		//Checks if the collision is with the ground
		else if(collision.gameObject.tag == "Ground")
		{
			Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), m_Collider);
		}
		//Checks if the collision is with the Spawner
		else if (collision.gameObject.tag == "Spawner")
		{
			Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), m_Collider);
		}
		//Checks if the collision is with the bullet
		if (collision.gameObject.tag == "Bullet")
		{
			m_rb.useGravity = true;
		}
	}
}