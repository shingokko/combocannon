using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	TextMesh textMesh;

	// Use this for initialization
	void Start () {
		textMesh = GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
		textMesh.text = "Score : " + GameData.Instance.score;
	}
}
