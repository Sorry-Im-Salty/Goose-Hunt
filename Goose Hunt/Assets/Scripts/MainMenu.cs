/*-------------------------------------------------------------------*
|  MAIN_MENU
|
|  Author:			Thomas Maltezos
| 
|  Description:		Handles both buttons within the menu.
*-------------------------------------------------------------------*/

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	private void Update()
	{
#if (UNITY_ANDROID) // VR controls.
		if (Input.GetButtonDown("Fire1"))
		{
			PlayGame();
		}
#endif
	}

	// Loads the next Scene after the Menu Scene within the Build Settings.
	public void PlayGame()
	{
		SceneManager.LoadScene(1);
	}

	// Debug is for confirmation within unity.
	public void QuitGame()
	{
		Debug.Log("App has Quit.");
		Application.Quit();
	}

}
