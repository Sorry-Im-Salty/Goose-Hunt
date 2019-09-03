using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponShoot : MonoBehaviour
{
	public Camera GunCamera;
	public float range = 100.0f;
	public ParticleSystem muzzleFlash;


	private void Awake()
	{
		muzzleFlash.Stop();
	}
	// Update is called once per frame
	void Update()
    {
		if (Input.GetButtonDown("Fire1"))
		{
			Shoot();
		}
    }

	void Shoot()
	{
		muzzleFlash.Play();
		RaycastHit hit;
		if (Physics.Raycast(GunCamera.transform.position, GunCamera.transform.forward, out hit, range))
		{
			Debug.Log(hit.transform.name);
		}
	}
}
