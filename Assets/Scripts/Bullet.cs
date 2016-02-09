using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public float moveSpeed = 30;

	bool _dead;
	GameObject _origin;
	GameObject _destination;

	void Start () {
		_origin = GameObject.Find("GunTip");
		_destination = GameObject.Find("EnemyHead");
		_dead = false;
		transform.position = _origin.transform.position;

		EnsureDestination();
	}

	bool V3Equal(Vector3 a, Vector3 b) {
		return Vector3.SqrMagnitude(a - b) < 0.0001;
 	}

 	void EnsureDestination() {
		if (_destination == null) {
			_dead = true;

			if (gameObject != null) {
				Destroy(gameObject, 0.1f);
			}
		}
 	}

	void Update () {
        if (_dead || _destination == null) { return; }

		EnsureDestination();

        var step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, _destination.transform.position, step);
        if (V3Equal(transform.position, _destination.transform.position)) {
			_dead = true;
			
			if (gameObject != null) {
				Destroy(gameObject, 0.1f);
			}
        }
	}
}
