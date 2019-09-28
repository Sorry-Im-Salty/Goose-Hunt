using UnityEngine;

/// <summary>
/// Manages the projectile resets.
/// </summary>

public class projectile : MonoBehaviour
{
    /// <summary>
    /// Timer will count up to 5.
    /// </summary>
	private float timer = 0.0f;

    /// <summary>
    /// Stores the rigidbody.
    /// </summary>
    private Rigidbody rb;


    /// <summary>
    /// Gets the rigidbody component on start.
    /// </summary>
    void Start()
    {
		rb = gameObject.GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Timer will count up to 5 then reset projectile.
    /// </summary>
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
