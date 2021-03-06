﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Start : Listable {

	public bool selected = true;

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
			SceneManager.LoadScene("Menu");
		}
	}


	void OnMouseDown() {
		transform.localScale *= 0.9f;
		PlayerHealth.Instance.currentHealth = 10;
		PlayerHealth.Instance.shake = 0;
	}

	void OnMouseUp() {
		SceneManager.LoadScene("Menu");
	}
}
