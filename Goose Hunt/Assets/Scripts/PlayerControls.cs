using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Player Controls.
// Created by Grant Roberts.
// Description: the controls for the player.

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

#if (UNITY_ANDROID) // VR controls.
	// The VR controller.
	private OVRInput.Controller m_VRController = OVRInput.Controller.None;
#endif

	// Constructor.
	void Awake()
    {
#if (UNITY_ANDROID) // VR controls.
		if (OVRInput.GetDominantHand() == OVRInput.Handedness.LeftHanded)
			m_VRController = OVRInput.Controller.LTouch;

		else
			m_VRController = OVRInput.Controller.RTouch;

#elif (UNITY_STANDALONE_WIN) // PC controls.
		// Lock the mouse to the centre of the screen. (Also hides the cursor)
		Cursor.lockState = CursorLockMode.Locked;

#endif
    }

    // Update the player.
    void Update()
    {
#if (UNITY_ANDROID) // VR controls.
	if (OVRInput.GetControllerPositionTracked(m_VRController))
	{
		m_Gun.transform.localRotation = OVRInput.GetLocalControllerRotation(m_VRController);
		m_Gun.transform.localPosition = OVRInput.GetLocalControllerPosition(m_VRController);
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