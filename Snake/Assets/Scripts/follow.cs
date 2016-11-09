using UnityEngine;
using System.Collections;

public class follow : MonoBehaviour {

	public GameObject snakeHead;
	private Vector3 offset;
	private PlayerController playerController;


	// Use this for initialization
	void Start () {
		playerController = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
		offset = transform.position - snakeHead.transform.position;
	}


	// Update is called once per frame
	void Update () {
		if (!playerController.isDead) {
			transform.position = Vector3.Lerp (transform.position, snakeHead.transform.position + offset, 0.1f);
		}
	}
}
