using UnityEngine;
using System.Collections;

public class Outline : MonoBehaviour {
	public float offsetX;

	void SetText(GameObject obj) {
		obj.GetComponent<TextMesh>().text = GetComponent<TextMesh>().text;
	}

	void Start() {
		if (offsetX != 0) {
			transform.Translate(new Vector3(offsetX, 0, 0));
		}

		var above = transform.Find("Above").gameObject;
		var below = transform.Find("Below").gameObject;
		var right = transform.Find("Right").gameObject;
		var left = transform.Find("Left").gameObject;

		SetText(above);
		SetText(below);
		SetText(right);
		SetText(left);
	}
}
