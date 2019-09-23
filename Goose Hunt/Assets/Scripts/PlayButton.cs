using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// The PlayButton
// Created by Grant Roberts
// Move on to the next scene.

public class PlayButton : MonoBehaviour
{
	private void OnCollisionEnter(Collision collision)
	{
#if (UNITY_ANDROID)
		if (collision.gameObject.tag == "Bullet")
			SceneManager.LoadScene(1);
#endif
	}
}
