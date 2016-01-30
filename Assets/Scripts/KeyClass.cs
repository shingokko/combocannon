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

}
