using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public abstract class Storyable : MonoBehaviour {
	public virtual bool GetFinished() {
		return false;
	}
	public virtual void StartStory() {}

	public virtual void SetVisible() {}

}
