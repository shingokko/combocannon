using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class SpriteParticle : MonoBehaviour {
	public bool enableRotation = true;

	bool _dead;
	GameObject _origin;
	GameObject _destination;
	Animator _animator;
	float _currentTime;
	float _currentAngle;
	float _life = 3;
	float _speed = 10;
	float _rotateZ = 0.1f;
	float _offsetX = 0.1f;
	float _offsetY = 0.1f;
	Vector3 _destinationPos;

	void Start () {
		_destination = GameObject.Find("EnemyHead");

		// destination does not exist, self-destruct
		if (_destination == null) {
			_dead = true;
			Destroy(gameObject, 0.2f);
		}
		else {
			_origin = GameObject.Find("GunTip");
			_speed = (float)Random.Range(10, 40);
			_currentTime = 0;

			if (enableRotation) {
				_rotateZ = (float)Random.Range(-10, 10);
				_currentAngle = transform.rotation.z;
			}

	    	var offsetX = ((float)Random.Range(-100, 100)) * 0.01f;
	    	var offsetY = ((float)Random.Range(-100, 100)) * 0.01f;

			_dead = false;
	    	transform.position = new Vector3
			(
				_origin.transform.position.x + offsetX,
				_origin.transform.position.y + offsetY,
				_origin.transform.position.z
			);

			_destinationPos = new Vector3
			(
				_destination.transform.position.x + offsetX,
				_destination.transform.position.y + offsetY,
				_destination.transform.position.z
			);

			_animator = GetComponent<Animator>();
			_animator.Play("break");
		}
	}

	void Update () {
		if (_dead) { return; }

		_currentTime += Time.deltaTime;
		if (_currentTime > _life) {
			_dead = true;
        	Destroy(gameObject, 0.2f);
		}
		else {
	        var step = _speed * Time.deltaTime;
	        transform.position = Vector3.MoveTowards(transform.position, _destinationPos, step);

	        if (enableRotation) {
		        _currentAngle += _rotateZ;
		        transform.rotation = Quaternion.Euler(0, 0, _currentAngle);
	        }
		}
	}
}
