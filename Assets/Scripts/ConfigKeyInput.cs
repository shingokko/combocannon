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
        if (e.isKey && selected && !e.keyCode.ToString().Equals("None") && e.keyCode != KeyCode.UpArrow && e.keyCode != KeyCode.DownArrow) {
        	//Conditional of Doom:
        	//	The event must be a key event
        	// The field must also be selected
        	// The keycode musnt be "none"(weird shit that happens) or Up or down arrows (would break the menu)
            Debug.Log("Detected key code: " + e.keyCode);
            UpdateBinding(e.keyCode);
        }
        
    }

    //Used by the user in the Config screen to remap a key.

	void UpdateBinding(KeyCode key) {
		Preferences.Instance.setKeyCode(keyMap, key);
		GetComponent<TextMesh>().text = key.ToString();
	}

}
