using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ConfigList : MonoBehaviour {
	//Placeholder, this allows multiple to be selected at one time. Need to implement list
	public Listable[] KeyBindingList;
	public int index = 0;


	void Update() {
		if (Input.GetKeyDown(KeyCode.DownArrow)) {
			next();
			Debug.Log("Down");
		}

		if (Input.GetKeyDown("up")) {
			prev();
			Debug.Log("Up");
		}
	}

	public void next() {
		index = (index + 1) % KeyBindingList.Length;
		Reselect();
	}

	public void prev() {
		if (index == 0)
			index = KeyBindingList.Length;
		index--;
		Reselect();
	}

	private void Reselect() {
		for (int i = 0; i < KeyBindingList.Length; i++) {
			if (i == index)
				(KeyBindingList[i]).setSelect(true);
			else
				(KeyBindingList[i]).setSelect(false);
		}
	}
}
