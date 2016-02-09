using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class Smoke : MonoBehaviour {
	float _currentTime;
	float _waitTime = 2.5f;
	GameObject _target;
	Animator _animator;

	void Start() {
		_currentTime = 0;
		
		_target = GameObject.Find("GunTip");
		_animator = GetComponent<Animator>();

    	var offsetX = ((float)Random.Range(-100, 100)) * 0.01f;
    	var offsetY = ((float)Random.Range(-100, 100)) * 0.01f;

    	transform.position = new Vector3
		(
			_target.transform.position.x + -0.5f,
			_target.transform.position.y + 0.5f,
			_target.transform.position.z
		);

		_animator.Play("smoke-expand");
	}

	void Update () {
        _currentTime += Time.deltaTime;
        if (_currentTime > _waitTime) {
			if (gameObject != null) {
        		Destroy(gameObject, 0.15f);
			}
        }
	}
}
