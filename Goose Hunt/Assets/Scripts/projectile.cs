/*-------------------------------------------------------------------*
|  PROJECTILE
|
|  Author:			Thomas Maltezos
| 
|  Description:		Manages the projectiles fired from the weapon.
*-------------------------------------------------------------------*/

using UnityEngine;

public class projectile : MonoBehaviour
{
	private float timer = 0.0f;
	private Rigidbody rb;

    void Start()
    {
		rb = gameObject.GetComponent<Rigidbody>();
    }

	// Projectiles will exist for 5 seconds, then be disabled and their velocity will be reset.
    void Update()
    {
		timer += Time.deltaTime;
		if (timer >= 5)
		{
			gameObject.SetActive(false);
			timer = 0;
			rb.velocity = new Vector3(0f, 0f, 0f);
			rb.angularVelocity = new Vector3(0f, 0f, 0f);
			rb.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
		}
    }
}
