using UnityEngine;
using System.Collections;

public class FadeOut : Storyable {
	public float speed = 10.0f;
	public float holdTime = 10.0f;
	public bool finished = false;
	private TextMesh toFadeMesh;
	private bool readyToFade = false;
	private Renderer rend;

	//Start this animation
	public override void StartStory() {
		Debug.Log("Start Story");
		toFadeMesh =GetComponent<TextMesh>();
		rend = GetComponent<Renderer>();
        rend.enabled = false;
        rend.enabled = true;
		Invoke("StartFade",holdTime);
	}

	public override bool GetFinished() {
		return finished;
	}

	void Update() {
		if (readyToFade) {
			toFadeMesh.color = Color.Lerp(toFadeMesh.color, Color.clear, speed * Time.deltaTime);
		}
		if (toFadeMesh.color.Equals(Color.clear)) {
			finished = true;
		}
	}

	void StartFade() {
		readyToFade = true;
	}


}
