using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
	// Mouse sensitivity on the x axis.
	public float m_MouseSensitivityX = 0.0f;

	// Mouse sensitivity on the y axis.
	public float m_MouseSensitivityY = 0.0f;

	// The gun.
	public GameObject m_Gun = null;

	// X rotation of the mouse.
	private float x = 0.0f;

	// Y rotation of the mouse.
	private float y = 0.0f;

	// If the VR controller is left handed.
	private bool m_LeftHanded = false;

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
		OVRInput.Controller c = OVRInput.Controller.Active;

		if (m_LeftHanded == true)
			c = OVRInput.Controller.LTouch;

		else
			c = OVRInput.Controller.RTouch;

		if (OVRInput.GetControllerPositionTracked(c))
		{
			m_Gun.transform.localRotation = OVRInput.GetLocalControllerRotation(c);
			m_Gun.transform.localPosition = OVRInput.GetLocalControllerPosition(c);
		}

#elif (UNITY_STANDALONE_WIN) // PC controls.
		// Get the x and y movement of the mouse.
		x += m_MouseSensitivityX * Input.GetAxis("Mouse X");
		y -= m_MouseSensitivityY * Input.GetAxis("Mouse Y");

		// Rotate the player by that much.
		transform.eulerAngles = new Vector3(y, x, 0.0f);
#endif
	}
}