using UnityEngine;
using System.Collections;

public class Smoke : MonoBehaviour {
	float _currentTime;
	float _waitTime = 0.2f;
	GameObject _target;

	void Start() {
		_currentTime = 0;
		_target = GameObject.Find("GunTip");
		transform.position = _target.transform.position;
	}

	void Update () {
        _currentTime += Time.deltaTime;
        if (_currentTime > _waitTime) {
        	GetComponent<ParticleSystem>().enableEmission = false;
        	Destroy(gameObject, 0.2f);
        }
	}
}
