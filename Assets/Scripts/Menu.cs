using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Menu : Listable {
	public bool selected = false;
	void OnMouseDown() {
		transform.localScale *= 0.9f;
	}

	void OnMouseUp() {
		SceneManager.LoadScene("Menu");
	}

	void Update() {
		if (selected && Input.GetKeyDown(KeyCode.Return)) {
			SceneManager.LoadScene("Menu");
		}
	}

	public override void setSelect(bool select) {
				Debug.Log("should be run");
		if (select != selected) {
			if (select) {
				transform.localScale /= 0.9f;
				selected = true;
			} else {
				transform.localScale *= 0.9f;
				selected = false;
			}
		}
	}

	public override bool getSelect() {
		return selected;
	}
 
}
