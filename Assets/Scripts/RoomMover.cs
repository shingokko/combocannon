using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RoomMover : MonoBehaviour {

	public KeyCode trigger = KeyCode.Return;
	public string NextRoom;
	void Update () {
		if (Controller.GetKeyDown(trigger)) {
			SceneManager.LoadScene(NextRoom);
		}
	}
}
