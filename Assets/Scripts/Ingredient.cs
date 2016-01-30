using UnityEngine;
using System.Collections;

public class Ingredient : MonoBehaviour {
	public float moveSpeed = 30;

	GameObject _target;

	void Start () {
		_target = GameObject.Find("Gun");
	}

	bool V3Equal(Vector3 a, Vector3 b) {
		return Vector3.SqrMagnitude(a - b) < 0.0001;
 	}

	void Update () {
        var step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, step);
        if (V3Equal(transform.position, _target.transform.position)) {
        	Destroy(gameObject, 0.1f);
        }
	}
}
