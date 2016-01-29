using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOver : MonoBehaviour {
	void OnMouseDown() {
		transform.localScale *= 0.9f;
	}

	void OnMouseUp() {
		SceneManager.LoadScene("GameOver");
	}
}
