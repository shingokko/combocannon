using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class KeyClass : MonoBehaviour {
	public KeyType _keyMap = KeyType.A;
	public KeyCode currentKeyCode = KeyCode.F;
	public bool _selected = false;

	public void setKeyCode(KeyCode newKeyCode) {
		currentKeyCode = newKeyCode;
	}

	void Update() {
		if ( _selected ) {
			// Some change to the GUI?
		}
	}

	void OnMouseDown() {
		transform.localScale *= 0.9f;
		_selected = true;
	}
}
