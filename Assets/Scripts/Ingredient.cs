using UnityEngine;
using System.Collections;

public class Ingredient : MonoBehaviour {
	public float moveSpeed = 42;
	public float zPos = -5;

	GameObject _target;

	void Start () {
		_target = GameObject.Find("IngredientSpot");
		transform.position = new Vector3(transform.position.x, transform.position.y, zPos);
		Debug.Log(transform.position.z);
	}

	bool V3Equal(Vector3 a, Vector3 b) {
		return Vector3.SqrMagnitude(a - b) < 0.0001;
 	}

	void Update () {
        var step = moveSpeed * Time.deltaTime;
        var targetPosWithoutZAxisChange = new Vector3(_target.transform.position.x, _target.transform.position.y, zPos);
        transform.position = Vector3.MoveTowards(transform.position, targetPosWithoutZAxisChange, step);
        if (V3Equal(transform.position, targetPosWithoutZAxisChange)) {
        	Destroy(gameObject, 0.1f);
        }
	}
}
