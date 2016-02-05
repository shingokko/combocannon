using UnityEngine;
using System.Collections;

public class Ingredient : MonoBehaviour {
	public float moveSpeed = 42;
	public float zPos = -4;
	GameObject _target;

	void Start () {
		_target = GameObject.Find("IngredientSpot");
		iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("Name1"), "time", 1.0f));
        Destroy(gameObject, 1.1f);
	}
     
}
