using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Gun : MonoBehaviour {
	public bool Tutorial = false;
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

	GameObject boneIngredient1;
	GameObject boneIngredient2;
	GameObject boneIngredient3;
	GameObject plantIngredient1;
	GameObject plantIngredient2;
	GameObject plantIngredient3;
	GameObject mineralIngredient1;
	GameObject mineralIngredient2;
	GameObject mineralIngredient3;
	GameObject fluidIngredient1;
	GameObject fluidIngredient2;
	GameObject fluidIngredient3;

	// particles
	GameObject boneParticles;

	// actions
	GameObject smoke;
	GameObject boneBullet;
	GameObject plantBullet;
	GameObject mineralBullet;
	GameObject fluidBullet;
	GameObject boneMachineGun;
	GameObject plantMachineGun;
	GameObject mineralMachineGun;
	GameObject fluidMachineGun;
	GameObject boneFire;

	// extra actions
	GameObject blueBullet;
	GameObject flames;
	
	// Enemies
	public int respawnTime = 300;
	GameObject _enemy = null;
	int _counter;
	IList<EnemyStats> _enemyStatsList;
	EnemyStats _currentEnemyStats;

	void Start () {
		_barrel = transform.Find("Barrel").GetComponent<Animator>();
		_cauldron = GameObject.Find("Cauldron").GetComponent<Animator>();

		_enemyStatsList = new List<EnemyStats>();
		_keys = new List<KeyType>();
		_keySequences = Preferences.Instance.RecipeList;

		LoadPrefabs();

		initializeEnemyList();
		RandomlySummon();
	}
	
	void LoadPrefabs() {
		// ingredients
		plantIngredient1 = (GameObject)Resources.Load("IngredientA_1");
		plantIngredient2 = (GameObject)Resources.Load("IngredientA_2");
		plantIngredient3 = (GameObject)Resources.Load("IngredientA_3");
		boneIngredient1 = (GameObject)Resources.Load("IngredientB_1");
		boneIngredient2 = (GameObject)Resources.Load("IngredientB_2");
		boneIngredient3 = (GameObject)Resources.Load("IngredientB_3");
		mineralIngredient1 = (GameObject)Resources.Load("IngredientC_1");
		mineralIngredient2 = (GameObject)Resources.Load("IngredientC_2");
		mineralIngredient3 = (GameObject)Resources.Load("IngredientC_3");
		fluidIngredient1 = (GameObject)Resources.Load("IngredientD_1");
		fluidIngredient2 = (GameObject)Resources.Load("IngredientD_2");
		fluidIngredient3 = (GameObject)Resources.Load("IngredientD_3");

		// particles
		boneParticles = (GameObject)Resources.Load("BoneParticles");

		// actions
		smoke = (GameObject)Resources.Load("Smoke");
		boneBullet = (GameObject)Resources.Load("BoneBullet");
		plantBullet = (GameObject)Resources.Load("PlantBullet");
		mineralBullet = (GameObject)Resources.Load("MineralBullet");
		fluidBullet = (GameObject)Resources.Load("FluidBullet");
		boneMachineGun = (GameObject)Resources.Load("BoneMachineGun");
		plantMachineGun = (GameObject)Resources.Load("PlantMachineGun");
		mineralMachineGun = (GameObject)Resources.Load("MineralMachineGun");
		fluidMachineGun = (GameObject)Resources.Load("FluidMachineGun");
		boneFire = (GameObject)Resources.Load("BlueBullet");

		// extra actions
		blueBullet = (GameObject)Resources.Load("BlueBullet");
		flames = (GameObject)Resources.Load("Flames");
	}

	void SpawnIngredient(KeyType key) {
        if (key == KeyType.Unknown && key == KeyType.Trigger) { return; }

		var ingredientVersion = UnityEngine.Random.Range(1, 3);

        GameObject ingredient = null;

    	if (key == KeyType.A) {
    		switch (ingredientVersion) {
    			case 1:
    				ingredient = plantIngredient1;
    				break;
				case 2:
    				ingredient = plantIngredient2;
					break;
				default:
    				ingredient = plantIngredient3;
					break;
    		}
    	}

    	if (key == KeyType.B) {
    		switch (ingredientVersion) {
    			case 1:
    				ingredient = boneIngredient1;
    				break;
				case 2:
    				ingredient = boneIngredient2;
					break;
				default:
    				ingredient = boneIngredient3;
					break;
    		}
    	}

    	if (key == KeyType.C) {
    		switch (ingredientVersion) {
    			case 1:
    				ingredient = mineralIngredient1;
    				break;
				case 2:
    				ingredient = mineralIngredient2;
					break;
				default:
    				ingredient = mineralIngredient3;
					break;
    		}
    	}

    	if (key == KeyType.D) {
    		switch (ingredientVersion) {
    			case 1:
    				ingredient = fluidIngredient1;
    				break;
				case 2:
    				ingredient = fluidIngredient2;
					break;
				default:
    				ingredient = fluidIngredient3;
					break;
    		}
    	}

    	if (ingredient != null) {
			Instantiate(ingredient);
    	}
	}

	void TrackKeys() {
		var currentKeyCount = _keys.Count;
		var keyPressed = KeyType.Unknown;
		if (EnemyHealth.Instance.currentHealth <= 0) {
			return;
		}

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
		    			Instantiate(boneParticles);
	    				ReduceEnemyHealth(2);
	        			break;
        			case "Plant Bullet":
		    			Instantiate(plantBullet);
	    				ReduceEnemyHealth(2);
        				break;
    				case "Mineral Bullet":
		    			Instantiate(mineralBullet);
	    				ReduceEnemyHealth(2);
    					break;
    				case "Fluid Bullet":
		    			Instantiate(fluidBullet);
	    				ReduceEnemyHealth(2);
    					break;
    				case "Bone Machine Gun":
		    			Instantiate(boneMachineGun);
	    				ReduceEnemyHealth(4);
    					break;
    				case "Plant Machine Gun":
		    			Instantiate(plantMachineGun);
	    				ReduceEnemyHealth(4);
    					break;
    				case "Mineral Machine Gun":
		    			Instantiate(mineralMachineGun);
	    				ReduceEnemyHealth(4);
    					break;
    				case "Fluid Machine Gun":
		    			Instantiate(fluidMachineGun);
	    				ReduceEnemyHealth(4);
    					break;
					case "Bone Fire":
						Instantiate(boneFire);
						ReduceEnemyHealth(6);
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

	void ReduceEnemyHealth(int reduceBy) {
		if (EnemyHealth.Instance.currentHealth - reduceBy <= 0) {
			EnemyHealth.Instance.currentHealth = 0;
		}
		else {
			EnemyHealth.Instance.currentHealth -= reduceBy;
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
			_counter += 1;

			if (_counter == respawnTime) {
				if (GameData.Instance.score % 1000 == 0) {
					summon(5);
				}
				else {
					summon(UnityEngine.Random.Range(1, 5));
				}
				
				_counter = 0;
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

		_currentEnemyStats = _enemyStatsList[enemyNum - 1];
		if (Tutorial) {
			_currentEnemyStats = new EnemyStats(1000, Element.Unknown);
		}
		EnemyHealth.Instance.maxHealth = _currentEnemyStats.getHealth();
		EnemyHealth.Instance.currentHealth = _currentEnemyStats.getHealth();
		if (Tutorial) {
			enemyName = "TutorialMonster";
		}
		_enemy = (GameObject)Resources.Load(enemyName);
		if (Tutorial) {
			Instantiate(_enemy, new Vector3(-10.0f, 0.0f, 0), Quaternion.identity);
			return;
		}
		Instantiate(_enemy, new Vector3(-0.4325213f, 0.0f, 0), Quaternion.identity);
	}

	public void initializeEnemyList() {
		_enemyStatsList.Add(new EnemyStats(10, Element.Plant));
		_enemyStatsList.Add(new EnemyStats(20, Element.Mineral));
		_enemyStatsList.Add(new EnemyStats(15, Element.Fluid));
		_enemyStatsList.Add(new EnemyStats(10, Element.Bone));
		_enemyStatsList.Add(new EnemyStats(50, Element.Unknown));
	}
}
