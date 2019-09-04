using UnityEngine;

public class projectile : MonoBehaviour
{
	private float timer = 0.0f;
	private Rigidbody rb;

    void Start()
    {
		rb = gameObject.GetComponent<Rigidbody>();
    }

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
