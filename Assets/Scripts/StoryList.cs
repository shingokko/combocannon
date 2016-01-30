using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StoryList : MonoBehaviour {
	//Placeholder, that plays a series of 'stories' in order.
	public Storyable[] StoryArray;
	public int index = 0;
	
	void Start() {
		Debug.Log("Start");
		StoryArray[index].StartStory();
	}
	
	void Update() {
		if (index < StoryArray.Length && StoryArray[index].GetFinished()) {
			NextStory();
		}
	}

	private void NextStory() {
		Debug.Log("Next Story");

		if (index < (StoryArray.Length - 1)) {
			index++;
			StoryArray[index].StartStory();
		} else {
			SceneManager.LoadScene("Tutorial");
		}
	}
	
}
