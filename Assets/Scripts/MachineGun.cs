using UnityEngine;
using System.Collections;

public class MachineGun : MonoBehaviour {
	bool _dead;
	float _currentTime;
	float _firingRate = 0.1f;

	GameObject _origin;
	GameObject _destination;

	public GameObject prefab;
	public int bulletCount = 5;

	void Start() {
		_dead = false;
		_currentTime = 0;
		_origin = GameObject.Find("GunTip");
		_destination = GameObject.Find("EnemyHead");
		
		if (_destination == null) {
			_dead = true;
		}
	}

	void Update () {
		if (_dead) {
			Destroy(gameObject, 1.0f);
			return;
		}

		if (bulletCount > 0) {
	        _currentTime += Time.deltaTime;
	        if (_currentTime > _firingRate) {
	        	var currentPos = prefab.transform.position;

	        	var offsetX = ((float)Random.Range(-50, 50)) * 0.05f;
	        	var offsetY = ((float)Random.Range(-50, 50)) * 0.05f;
	        	var offsetPos = new Vector3(currentPos.x + offsetX, currentPos.y + offsetY, currentPos.z);

        		prefab.transform.position = offsetPos;

	        	Instantiate(prefab);

	        	_currentTime = 0;
	        	bulletCount -= 1;
	        }
		}
		else {
			_dead = true;
		}
	}

}
