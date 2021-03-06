using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Config : Listable {

	public bool selected = false;

	public override void setSelect(bool select) {
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

	void Update() {
		if (selected && Controller.GetKeyDown(KeyCode.Return)) {
			SceneManager.LoadScene("Config");
		}
	}

	void OnMouseDown() {
		transform.localScale *= 0.9f;
	}

	void OnMouseUp() {
		SceneManager.LoadScene("Config");
	}
}
