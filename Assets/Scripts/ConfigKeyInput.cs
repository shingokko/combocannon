using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ConfigKeyInput : Listable {
	public KeyType keyMap = KeyType.A; //Provided by the class specific instance in the config menu
	public bool selected = false;

	void Start() {
		GetComponent<TextMesh>().text = Preferences.Instance.getKeyCode(keyMap).ToString();
	}
	
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
 
	void OnGUI() {
        Event e = Event.current;
        if (e.type == EventType.KeyUp && selected && isLegal(e.keyCode)) {
        	//Conditional of Doom:
        	//	The event must be a key event
        	// The field must also be selected
        	// The keycode musnt be "none"(weird shit that happens) or Up or down arrows (would break the menu)
            Debug.Log("Detected key code: " + e.keyCode);
            UpdateBinding(e.keyCode);
        }
        
    }
	void Update() {
		KeyCode k = Controller.GetLastButton();
		if (k != KeyCode.None && k != KeyCode.UpArrow && k != KeyCode.DownArrow && selected) {
			UpdateBinding(Controller.GetLastButton());
		}
	}

    //Used by the user in the Config screen to remap a key.

	void UpdateBinding(KeyCode key) {
		Preferences.Instance.setKeyCode(keyMap, key);
		GetComponent<TextMesh>().text = key.ToString();
	}
	
	bool isLegal(KeyCode key) {
		if (key > KeyCode.None && key < KeyCode.Numlock && key != KeyCode.UpArrow && key != KeyCode.DownArrow) {
			return true;
		}
		return false;
	}

}
