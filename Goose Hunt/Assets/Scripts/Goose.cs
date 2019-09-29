using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//File Name: Goose
//Created by Connor Li
//Description: Controls the object flying objects.

/**
* File Name: Goose
* 
* Created by Connor Li.
* 
* Description: Controls the object flying objects.
*/
public class Goose : MonoBehaviour
{
    /**
    * Timer till object is despawned
    */
    float m_timer;
    /**
    * Minimum x velocity
    */
	public float m_xVelocityMin = 10.0f;
    /**
    * Maximum x velocity
    */
    public float m_xVelocityMax = 20.0f;
    /**
    * y velocity
    */
    public float m_yVelocity = 20.0f;
    /**
    * Gets the spawners transform
    */
    Transform m_Spawner;
    /**
    * Holds its collider
    */
    Collider m_Collider;
    /**
    * Holds its rigidbody
    */
    Rigidbody m_rb;

    void Awake()
    {
		m_Spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Transform>();
		m_rb = gameObject.GetComponent<Rigidbody>();
		m_Collider = gameObject.GetComponent<Collider>();
		m_rb.velocity = new Vector3(Random.Range(m_xVelocityMin, m_xVelocityMax), m_yVelocity, 0.0f);
    }


    void Update()
    {
		m_timer += Time.deltaTime;
        //Resets the goose
        /**
         * Resets the goose
        */
        if (m_timer >= 5.0f)
		{
			gameObject.SetActive(false);
			m_rb.useGravity = false;
			gameObject.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 1.0f);
			gameObject.transform.position = GetComponentInParent<Transform>().position;
			m_rb.velocity = new Vector3(Random.Range(m_xVelocityMin, m_xVelocityMax), m_yVelocity, 0.0f);
			m_timer = 0.0f;
		}
    }

	private void OnCollisionEnter(Collision collision)
	{
        //Checks if the collision is with another goose
        /**
        * Checks if the collision is with another goose
        */
        if (collision.gameObject.tag == "Goose")
		{
			Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), m_Collider);
		}
        //Checks if the collision is with the ground
        /**
        * Checks if the collision is with the ground
        */
        else if (collision.gameObject.tag == "Ground")
		{
			Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), m_Collider);
		}
        //Checks if the collision is with the Spawner
        /**
        * Checks if the collision is with the Spawner
        */
        else if (collision.gameObject.tag == "Spawner")
		{
			Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), m_Collider);
		}
        //Checks if the collision is with the bullet
        /**
         * Checks if the collision is with the bullet
         */
        if (collision.gameObject.tag == "Bullet")
		{
			m_rb.useGravity = true;
			Score.scoreNum++;
		}
	}
}