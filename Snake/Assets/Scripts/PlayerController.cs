using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject preBody;

	public int count; 
	public bool isDead;

	private float timer = 0f;
	private Vector3 forward = Vector3.forward;

	private GameObject[] bodys;
	private AudioSource audioSource;



	// Use this for initialization
	void Start () {

		audioSource = GetComponent<AudioSource> ();

		bodys = new GameObject[100];

		bodys [0] = gameObject;
		bodys [1] = preBody;
		count = 2;

		isDead = false;
	}
	
	// Update is called once per frame
	void Update () {

		forward = currentForward ();
		timer += Time.deltaTime;
		if (timer > 0.3f) {
			followMove ();
			transform.position += forward;
			timer = 0f;
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Egg") {
			count++;
			changeLength ();
			audioSource.Play ();
		}
	}

	void OnCollisionEnter(Collision other) {
		print ("collision");
		if (other.gameObject.tag == "Wall") {
			isDead = true;
		}
	}

	Vector3 currentForward() {
		if (Input.GetKeyDown (KeyCode.W)) {
			return Vector3.forward;
		} else if (Input.GetKeyDown (KeyCode.S)) {
			return Vector3.back;
		} else if (Input.GetKeyDown (KeyCode.A)) {
			return Vector3.left;
		} else if (Input.GetKeyDown (KeyCode.D)) {
			return Vector3.right;
		} else {
			return forward;
		}
	}

	void followMove() {
		if (!isDead) {
			for (int i = count - 1; i > 0; i--) {
				bodys [i].transform.position = bodys [i - 1].transform.position;
			}
		}
	}

	void changeLength () {
		GameObject newBody = GameObject.Instantiate (preBody);
		bodys [count - 1] = newBody;
	}
}
