using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public float moveSpeed = 10;

	bool _dead;
	GameObject _origin;
	GameObject _destination;

	void Start () {
		_origin = GameObject.Find("GunTip");
		_destination = GameObject.Find("EnemyHead");
		_dead = false;
		transform.position = _origin.transform.position;

		if (_destination == null) {
			_dead = true;
			Destroy(gameObject, 0.1f);
		}
	}

	bool V3Equal(Vector3 a, Vector3 b) {
		return Vector3.SqrMagnitude(a - b) < 0.0001;
 	}

	void Update () {
		if (_dead) { return; }

        var step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, _destination.transform.position, step);
        if (V3Equal(transform.position, _destination.transform.position)) {
			_dead = true;

        	Destroy(gameObject, 0.1f);
        }
	}
}
