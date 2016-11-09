using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameConotroller : MonoBehaviour {

	public Text scoreLabel;
	public Text resultLabel;
	public AudioClip deadClip;

	private PlayerController playerController;
	private int count;
	private AudioSource audioSource;

	void Awake () {
		playerController = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
		audioSource = GetComponent<AudioSource> ();
	}

	void Update () {
		count = playerController.count - 2;
		scoreLabel.text = "Score: " + count.ToString ();

		if (playerController.isDead == true) {
			resultLabel.text = "YOU DEAD!";
			if (audioSource.isPlaying) {
				audioSource.Stop ();
				AudioSource.PlayClipAtPoint (deadClip, transform.position);
			}
		}
	}
}
