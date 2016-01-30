using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
	float _currentTime;
	float _waitTime = 0.6f;
	GameObject _target;

	void Start() {
		_currentTime = 0;
		_target = GameObject.Find("EnemyHead");
		transform.position = _target.transform.position;


	}

	void Update () {
        _currentTime += Time.deltaTime;
        if (_currentTime > _waitTime) {
        	Destroy(gameObject, 0.1f);
        }
	}
}
