using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class KeyClassReader : MonoBehaviour {

	public static void setPlayerKey(KeyType keyMap, KeyCode newKey) {
		GameObject KeyObj = GameObject.Find(getGameObjectName(keyMap));
		var comp = KeyObj.GetComponent<KeyClass>();
		comp.setKeyCode(newKey);
	}

	public static KeyCode getPlayerKey(KeyType keyMap) {
		GameObject KeyObj = GameObject.Find(getGameObjectName(keyMap));
		var comp = KeyObj.GetComponent<KeyClass>();
		return comp.currentKeyCode;
	}

	private static string getGameObjectName(KeyType key) {
		switch (key) {
			case KeyType.A:
				return "KeyA";
			case KeyType.B:
				return "KeyB";
			case KeyType.C:
				return "KeyC";
			case KeyType.D:
				return "KeyD";
			case KeyType.Trigger:
				return "KeyTrigger";
			default:
				return string.Empty;
		}
	}
}
