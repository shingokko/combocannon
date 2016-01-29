using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Gun : MonoBehaviour {
	bool _trackingKeys;
	float _currentTime;
	float _allowedTime = 0.6f;
	IList<KeyType> _keys;
	IList<KeySequence> _keySequences;

	void Start () {
		_keys = new List<KeyType>();

		_keySequences = new List<KeySequence>
		{
			new KeySequence
			(
				"Action 1", new KeyType[] { KeyType.A, KeyType.B, KeyType.Trigger } // action 1
			),
			new KeySequence
			(
				"Action 2", new KeyType[] { KeyType.A, KeyType.B, KeyType.C, KeyType.Trigger } // action 2
			),
			new KeySequence
			(
				"Action 3", new KeyType[] { KeyType.A, KeyType.B, KeyType.C, KeyType.D, KeyType.Trigger } // action 3
			)
		};
	}
	
	void TrackKeys() {
		var currentKeyCount = _keys.Count;

        if (Input.GetKeyDown("a")) {
        	_keys.Add(KeyType.A);
        }

        if (Input.GetKeyDown("s")) {
        	_keys.Add(KeyType.B);
        }

        if (Input.GetKeyDown("d")) {
        	_keys.Add(KeyType.C);
        }

        if (Input.GetKeyDown("f")) {
        	_keys.Add(KeyType.D);
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
        	_keys.Add(KeyType.Trigger);
        }

        if (currentKeyCount == 0 && _keys.Count > 0) {
        	_trackingKeys = true;
        }

        if (_keys.Count == 0) {
			_trackingKeys = false;
        }
        else {
        	if (currentKeyCount == 0) {
        		// start tracking keys, reset time
        		_trackingKeys = true;
        		_currentTime = 0;
        	}
        }

		if (_trackingKeys) {
	        _currentTime += Time.deltaTime;
	        if (_currentTime > _allowedTime) {
				_keys = new List<KeyType>();
				_currentTime = 0;
	        }
		}
	}

	void Update () {
		TrackKeys();

		foreach (var keySequence in _keySequences) {
	        if (keySequence.Check(_keys)) {
	        	Debug.LogFormat("Trigger {0}!", keySequence.name);
	        	// now an action has been triggered, reset keys
	        	_keys = new List<KeyType>();
	        }
		}

		/*
        var keysPressed = string.Empty;
        for (var index = 0; index < _keys.Count; index++) {
        	keysPressed += string.Format("{0}:{1}, ", index + 1, Enum.GetName(typeof(KeyType), _keys[index]));
        }

        if (!string.IsNullOrEmpty(keysPressed)) {
    		Debug.Log(keysPressed);
        }
        */
	}
}
