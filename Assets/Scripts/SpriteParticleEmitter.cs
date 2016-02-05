using UnityEngine;
using System.Collections;

public class SpriteParticleEmitter : MonoBehaviour {
	bool _dead;
	float _currentTime;
	float _firingRate = 0.025f;

	public GameObject prefab;
	public int particleCount = 6;

	void Start() {
		_dead = false;
		_currentTime = 0;
	}

	void Update () {
		if (_dead) {
			Destroy(gameObject, 1.0f);
			return;
		}

		if (particleCount > 0) {
	        _currentTime += Time.deltaTime;
	        if (_currentTime > _firingRate) {
	        	Instantiate(prefab);

	        	_currentTime = 0;
	        	particleCount -= 1;
	        }
		}
		else {
			_dead = true;
		}
	}
}
