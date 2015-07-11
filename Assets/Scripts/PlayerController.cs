using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	/* Public vars */
	public float speed;
	public Text countText;
	public Text winText;

	/* Private vars */
	private Rigidbody rb;
	private int count;

	/* Happens at the start of the game */
	void Start() {
		rb = GetComponent<Rigidbody>();
		count = 0;
		setCountText();
		winText.text = "";
	}

	/* Update every frame */
	void FixedUpdate() {

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}

	/* Events triggered when colliding */
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			count++;
			setCountText();
		}
	}

	void setCountText() {
		countText.text = "Score: " + count.ToString();
		if (count >= 12) {
			winText.text = "YOU WIN!";
		}
	}
}