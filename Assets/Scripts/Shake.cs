using UnityEngine;
using System.Collections;

public class Shake : MonoBehaviour {
	public float _moveSpeed = 2;
	public float _maxDistance = 0.2f;
	public bool moveUpAndDownInstead;
	float _currentWaitTime;
	float _maxWaitTime = 0.2f;
	int _direction = 1;
	float _startingXPos = 0;
	float _startingYPos = 0;
	float _left = 0;
	float _top = 0;
	float _right = 0;
	float _down = 0;
	Vector3 _velocity;

	void Start () {
		_currentWaitTime = 0;
		_velocity = Vector3.zero;
		_startingXPos = transform.position.x;
		_startingYPos = transform.position.y;
		_left = _startingXPos - _maxDistance;
		_top = _startingYPos + _maxDistance;
		_right = _startingXPos + _maxDistance;
		_down = _startingYPos - _maxDistance;
	}
	
	void Update () {
		_currentWaitTime += Time.deltaTime;

		if (_currentWaitTime > _maxWaitTime) {
			_currentWaitTime = 0;

			if (moveUpAndDownInstead) {
				_velocity.y = _moveSpeed * _direction;

				if ((_direction == 1 && transform.position.y > _top) || _direction == -1 && transform.position.y < _down) {
					_direction *= -1; // face the other way
				}

				_velocity.x = 0;
			}
			else {
				_velocity.x = _moveSpeed * _direction;

				if ((_direction == 1 && transform.position.x > _right) || _direction == -1 && transform.position.x < _left) {
					_direction *= -1; // face the other way
				}

				_velocity.y = 0;
			}

			transform.Translate(_velocity * Time.deltaTime);
		}
	}
}
