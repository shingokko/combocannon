using UnityEngine;
using System.Collections;

public class FadeOut : Storyable {
	public float fadeTime = 1.0f;
	public float holdTime = 10.0f;
	public bool finished = false;
	private TextMesh toFadeMesh;
	private bool readyToFade = false;
	private Renderer rend;

	void Start() {
		toFadeMesh = GetComponent<TextMesh>();
		Debug.Log(toFadeMesh.color.ToString());
		rend = GetComponent<Renderer>();
        rend.enabled = false;
	}
	//Start this animation
	public override void StartStory() {
		Debug.Log("Start Story");
		toFadeMesh = GetComponent<TextMesh>();
		Debug.Log(toFadeMesh.color.ToString());
		rend = GetComponent<Renderer>();
        rend.enabled = false;
        rend.enabled = true;
		Invoke("StartFade",holdTime);
	}

	public override bool GetFinished() {
		return finished;
	}

	void Update() {
		if (toFadeMesh == null) {
			toFadeMesh = GetComponent<TextMesh>();
		}
		if (readyToFade) {
			toFadeMesh.color = Color.Lerp(toFadeMesh.color, Color.clear, fadeTime * Time.deltaTime);
			Debug.Log(toFadeMesh.color.ToString());
		}

	}

	void StartFade() {
		readyToFade = true;
		Invoke("finish", fadeTime + 0.5f);
	}

	void finish() {
		Debug.Log("Finished");
		finished = true;
	}


}
