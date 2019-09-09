/*-------------------------------------------------------------------*
|  WEAPON_SHOOT
|
|  Author:			Thomas Maltezos
| 
|  Description:		Handles the shooting mechanic.
|
|  Example:			Shoots projectiles from the orion, with the
|					centre of the screen being the target.
*-------------------------------------------------------------------*/

using UnityEngine;

public class weaponShoot : MonoBehaviour
{
	public GameObject Gun;
	private GameObject prefab;

	// Loads the projectiles.
	void Start()
	{
		prefab = Resources.Load("Projectile") as GameObject;
	}

	// Gets the input for firing.
	void Update()
    {
		if (Input.GetButtonDown("Fire1"))
		{
			Shoot();
		}
    }

	// Gets the pooled projectile object and fires it from the origin if not null.
	void Shoot()
	{
		GameObject Projectile = objectPool.sharedInstance.GetPooledObject();
		if (Projectile != null)
		{
			Projectile.transform.position = transform.position + Gun.transform.forward * 2;
			Rigidbody rb = Projectile.GetComponent<Rigidbody>();
			rb.velocity = Gun.transform.forward * 40;
			Projectile.SetActive(true);
		}
	}
}