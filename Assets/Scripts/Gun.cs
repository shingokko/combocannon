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

	GameObject ingredientA;
	GameObject ingredientB;
	GameObject ingredientC;
	GameObject ingredientD;
	GameObject smoke;
	GameObject boneBullet;
	GameObject plantBullet;
	GameObject mineralBullet;
	GameObject fluidBullet;
	GameObject blueBullet;
	GameObject flames;
	
	//Enemies
	GameObject enemy = null;
	public int respawnTime = 300;
	private int counter;
	List<EnemyStats> enemyStatsList = new List<EnemyStats>();

	void Start () {
		_barrel = transform.Find("Barrel").GetComponent<Animator>();
		_cauldron = GameObject.Find("Cauldron").GetComponent<Animator>();
		_keys = new List<KeyType>();
		_keySequences = Preferences.Instance.RecipeList;

		LoadPrefabs();

		initializeEnemyList();
		RandomlySummon();
	}
	
	void LoadPrefabs() {
		ingredientA = (GameObject)Resources.Load("IngredientA");
		ingredientB = (GameObject)Resources.Load("IngredientB");
		ingredientC = (GameObject)Resources.Load("IngredientC");
		ingredientD = (GameObject)Resources.Load("IngredientD");
		smoke = (GameObject)Resources.Load("Smoke");
		boneBullet = (GameObject)Resources.Load("BoneBullet");
		plantBullet = (GameObject)Resources.Load("PlantBullet");
		mineralBullet = (GameObject)Resources.Load("MineralBullet");
		fluidBullet = (GameObject)Resources.Load("FluidBullet");
		blueBullet = (GameObject)Resources.Load("BlueBullet");
		flames = (GameObject)Resources.Load("Flames");
	}

	void SpawnIngredient(KeyType key) {
        if (key == KeyType.Unknown && key == KeyType.Trigger) { return; }

        GameObject ingredient = null;

    	if (key == KeyType.A) {
    		ingredient = ingredientA;
    	}

    	if (key == KeyType.B) {
    		ingredient = ingredientB;
    	}

    	if (key == KeyType.C) {
    		ingredient = ingredientC;
    	}

    	if (key == KeyType.D) {
    		ingredient = ingredientD;
    	}

    	if (ingredient != null) {
			Instantiate(ingredient);
    	}
	}

	void TrackKeys() {
		var currentKeyCount = _keys.Count;
		var keyPressed = KeyType.Unknown;

        if (Input.GetKeyDown(Preferences.Instance.getKeyCode(KeyType.A))) {
        	_keys.Add(KeyType.A);
        	keyPressed = KeyType.A;
        }

        if (Input.GetKeyDown(Preferences.Instance.getKeyCode(KeyType.B))) {
        	_keys.Add(KeyType.B);
        	keyPressed = KeyType.B;
        }

        if (Input.GetKeyDown(Preferences.Instance.getKeyCode(KeyType.C))) {
        	_keys.Add(KeyType.C);
        	keyPressed = KeyType.C;
        }

        if (Input.GetKeyDown(Preferences.Instance.getKeyCode(KeyType.D))) {
        	_keys.Add(KeyType.D);
        	keyPressed = KeyType.D;
        }

        if (Input.GetKeyDown(Preferences.Instance.getKeyCode(KeyType.Trigger))) {
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

        var keySequenceIsValidSoFar = false;
		foreach (var keySequence in _keySequences) {
	        if (keySequence.CheckSoFar(_keys)) {
        		keySequenceIsValidSoFar = true;
	        	break;
	        }
		}

		if (_trackingKeys) {
	        _currentTime += Time.deltaTime;

	        if (_currentTime > _allowedTime) {
	        	if (keySequenceIsValidSoFar) {
	    			Instantiate(smoke);
				}

				_keys = new List<KeyType>();
				_currentTime = 0;

        		SetIdle();
	        }
	        else {
				if (keySequenceIsValidSoFar) {
					OpenCauldron();
		        	SpawnIngredient(keyPressed);
				}
	        }
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
	        		case "Bone Bullet":
		    			Instantiate(boneBullet);

		    			if (EnemyHealth.Instance.currentHealth >= 0) {
		    				EnemyHealth.Instance.currentHealth -= 1;
		    			}
						else {
		    				EnemyHealth.Instance.currentHealth = 0;
		    			}
		    			

	        			break;
        			case "Plant Bullet":
		    			Instantiate(plantBullet);

		    			if (EnemyHealth.Instance.currentHealth >= 0) {
		    				EnemyHealth.Instance.currentHealth -= 2;
		    			}
						else {
		    				EnemyHealth.Instance.currentHealth = 0;
		    			}

        				break;
    				case "Fluid Bullet":
		    			Instantiate(fluidBullet);

		    			if (EnemyHealth.Instance.currentHealth >= 0) {
		    				EnemyHealth.Instance.currentHealth -= 3;
		    			}
						else {
		    				EnemyHealth.Instance.currentHealth = 0;
		    			}

    					break;
    				case "Mineral Bullet":
		    			Instantiate(mineralBullet);

		    			if (EnemyHealth.Instance.currentHealth >= 0) {
		    				EnemyHealth.Instance.currentHealth -= 4;
		    			}
						else {
		    				EnemyHealth.Instance.currentHealth = 0;
		    			}

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

		//Respawn
		if (EnemyHealth.Instance.currentHealth <= 0) {
			counter += 1;

			if (counter == respawnTime) {
				if (GameData.Instance.score % 1000 == 0) {
					summon(5);
				}
				else {
					summon(UnityEngine.Random.Range(1, 5));
				}
				
				counter = 0;
			}
		}
	}

	public void RandomlySummon() {
		summon(UnityEngine.Random.Range(1, 5));
	}
	
	public void summon(int enemyNum) {
		var enemyName = string.Empty;

		switch (enemyNum) {
			case 2:
				enemyName = "Monster2";
				break;
			case 3:
				enemyName = "Monster3";
				break;
			case 4:
				enemyName = "Monster4";
				break;
			case 5:
				enemyName = "Monster5";
				break;
			default:
				enemyName = "Monster1";
				break;	
		}


		EnemyHealth.Instance.maxHealth = enemyStatsList[enemyNum - 1].getHealth();
		EnemyHealth.Instance.currentHealth = enemyStatsList[enemyNum - 1].getHealth();

		enemy = (GameObject)Resources.Load(enemyName);
		Instantiate(enemy, new Vector3(-0.4325213f, 0.0f, 0), Quaternion.identity);
	}

	public void initializeEnemyList() {
		enemyStatsList.Add(new EnemyStats(10));
		enemyStatsList.Add(new EnemyStats(20));
		enemyStatsList.Add(new EnemyStats(15));
		enemyStatsList.Add(new EnemyStats(10));
		enemyStatsList.Add(new EnemyStats(50));
	}
}
