using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ConfigKeyInput : MonoBehaviour {
	public KeyType keyMap = KeyType.A;
	public bool selected = false;
	
	public void setSelect(bool select) {
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

	void UpdateBinding(KeyCode key) {
		KeyClassReader.setPlayerKey(keyMap,	key);
		GetComponent<TextMesh>().text = key.ToString();
	}

}
