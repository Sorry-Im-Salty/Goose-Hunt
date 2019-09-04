using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
	public float m_MouseSensitivityX = 0.0f;
	public float m_MouseSensitivityY = 0.0f;

	private float x = 0.0f;
	private float y = 0.0f;

    // Constructor.
    void Awake()
    {
		// Lock the mouse to the centre of the screen. (Also hides the cursor)
		Cursor.lockState = CursorLockMode.Locked;
    }

    // Update the player.
    void Update()
    {
#if (UNITY_ANDROID) // VR controls.
		
		
#elif (UNITY_STANDALONE_WIN) // PC controls.
		// Get the x and y movement of the mouse.
		x += m_MouseSensitivityX * Input.GetAxis("Mouse X");
		y -= m_MouseSensitivityY * Input.GetAxis("Mouse Y");

		// Rotate the player by that much.
		transform.eulerAngles = new Vector3(y, x, 0.0f);
#endif
	}
}