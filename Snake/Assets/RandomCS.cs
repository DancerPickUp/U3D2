using UnityEngine;
using System.Collections;

public class RandomCS : MonoBehaviour {

	public GameObject preEgg;

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Player") {
			RandomEgg ();
			Destroy (gameObject);
		}
	}
	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Player") {
			
		}
	}

	public void RandomEgg() {
		float x = Random.Range (-23.5f, 23.5f);
		float z = Random.Range (-23.5f, 23.5f);

		GameObject newEgg = GameObject.Instantiate (preEgg);
		newEgg.transform.position = new Vector3 (x, 0.5f, z);
	}

}
