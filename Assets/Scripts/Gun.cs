using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Gun : MonoBehaviour {
	bool _trackingKeys;
	float _currentTime;
	float _allowedTime = 0.6f;

	bool _actionInQueue;
	string _actionName;
	float _currentDelay;
	float _delayActionBy = 0.4f;

	bool _lidOpen;

	Animator _barrel;
	Animator _cauldron;

	IList<KeyType> _keys;
	IList<KeySequence> _keySequences;

	void Start () {
		_barrel = transform.Find("Barrel").GetComponent<Animator>();
		_cauldron = GameObject.Find("Cauldron").GetComponent<Animator>();

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
	
	void SpawnIngredient(KeyType key) {
        if (key == KeyType.Unknown && key == KeyType.Trigger) { return; }

        GameObject ingredient = null;

    	if (key == KeyType.A) {
    		ingredient = (GameObject)Resources.Load("IngredientA");
    	}

    	if (key == KeyType.B) {
    		ingredient = (GameObject)Resources.Load("IngredientB");
    	}

    	if (key == KeyType.C) {
    		ingredient = (GameObject)Resources.Load("IngredientC");
    	}

    	if (key == KeyType.D) {
    		ingredient = (GameObject)Resources.Load("IngredientD");
    	}

    	if (ingredient != null) {
			Instantiate(ingredient);
    	}
	}

	void TrackKeys() {
		var currentKeyCount = _keys.Count;
		var keyPressed = KeyType.Unknown;

        if (Input.GetKeyDown("a")) {
        	_keys.Add(KeyType.A);
        	keyPressed = KeyType.A;
        }

        if (Input.GetKeyDown("s")) {
        	_keys.Add(KeyType.B);
        	keyPressed = KeyType.B;
        }

        if (Input.GetKeyDown("d")) {
        	_keys.Add(KeyType.C);
        	keyPressed = KeyType.C;
        }

        if (Input.GetKeyDown("f")) {
        	_keys.Add(KeyType.D);
        	keyPressed = KeyType.D;
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
        	_keys.Add(KeyType.Trigger);
        	keyPressed = KeyType.Trigger;
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

        		SetIdle();
	        }
		}

        var doAnimateIngredient = false;
		foreach (var keySequence in _keySequences) {
	        if (keySequence.CheckSoFar(_keys)) {
        		OpenCauldron();
	        	doAnimateIngredient = true;
	        	break;
	        }
		}

		if (doAnimateIngredient) {
        	SpawnIngredient(keyPressed);
		}
	}

	void SetIdle() {
		_barrel.Play("idle");
		_barrel.speed = 0;

		_cauldron.Play("idle");
		_cauldron.speed = 0;
	}

	void OpenCauldron() {
		_barrel.Play("fire", -1, 0.2f);
		_barrel.speed = 0;

		_cauldron.Play("open", -1, 0.2f);
		_cauldron.speed = 0;
	}

	void CloseCauldron() {
		_barrel.speed = 1;
		_cauldron.speed = 1;
	}

	void TriggerAction() {
		if (_actionInQueue) {
	        _currentDelay += Time.deltaTime;
	        if (_currentDelay > _delayActionBy) {

	        	switch (_actionName) {
	        		case "Action 1":
		    			var bullet = (GameObject)Resources.Load("BlueBullet");
		    			Instantiate(bullet);
	        			break;
        			case "Action 2":
		    			var flames = (GameObject)Resources.Load("Flames");
		    			Instantiate(flames);
        				break;
    				case "Action 3":
		    			var bullet3 = (GameObject)Resources.Load("BlueBullet");
		    			Instantiate(bullet3);
    					break;
					default:
						break;
	        	}

	        	_actionInQueue = false;
				_currentDelay = 0;
				_actionName = string.Empty;
	        }
		}
	}

	void Update () {
		TrackKeys();

		if (!_actionInQueue) {
			foreach (var keySequence in _keySequences) {
		        if (keySequence.Check(_keys)) {
        			Invoke("CloseCauldron", 0.4f);

		        	_actionInQueue = true;
		        	_currentDelay = 0;
		        	_actionName = keySequence.name;

		        	// now an action has been triggered, reset keys
		        	_keys = new List<KeyType>();
		        }
			}
		}

		TriggerAction();
	}
}
