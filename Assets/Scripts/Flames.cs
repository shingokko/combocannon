using UnityEngine;
using System.Collections;

public class Flames : MonoBehaviour {
	float _currentTime;
	float _waitTime = 0.6f;
	GameObject _origin;
	ParticleSystem _particleSystem;
	
	void Start() {
		_currentTime = 0;
		_origin = GameObject.Find("GunTip");
		_particleSystem = GetComponent<ParticleSystem>();
		transform.position = _origin.transform.position;
	}

	void Update () {
        _currentTime += Time.deltaTime;
        if (_currentTime > _waitTime) {
        	_particleSystem.enableEmission = false; // stop playing
        	Destroy(gameObject, 0.2f);
        }
	}
}
