using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(EnemyStatsTracker))]
[RequireComponent(typeof(GunPrefabs))]
public class Gun : MonoBehaviour
{
    int _keyCapacity = 5;

    bool _actionInQueue;
    string _actionName;
    float _currentDelay;
    float _delayActionBy = 0.4f;

    bool _lidOpen;

    Animator _barrel;
    Animator _cauldron;

    IList<KeyType> _keys;
    IList<KeySequence> _keySequences;

    GunPrefabs _gunPrefabs;
    EnemyStatsTracker _enemyStatsTracker;
    CannonContentsDisplay _cannonContentsDisplay;

    void Start()
    {
        _barrel = transform.Find("Barrel").GetComponent<Animator>();
        _cauldron = transform.Find("Cauldron").GetComponent<Animator>();

        _keys = new List<KeyType>();
        _keySequences = Preferences.Instance.RecipeList;

        _gunPrefabs = GetComponent<GunPrefabs>();
        _enemyStatsTracker = GetComponent<EnemyStatsTracker>();

        _cannonContentsDisplay = GameObject.Find("CannonContentsDisplay").GetComponent<CannonContentsDisplay>();
    }

    void SpawnIngredient(KeyType key)
    {
        if (key == KeyType.Unknown && key == KeyType.Trigger)
        {
            return;
        }

        var ingredientVersion = UnityEngine.Random.Range(1, 4);

        GameObject ingredient = null;

        if (key == KeyType.A) {
            switch (ingredientVersion) {
                case 1:
                    ingredient = _gunPrefabs.plantIngredient1;
                    break;
                case 2:
                    ingredient = _gunPrefabs.plantIngredient2;
                    break;
                default:
                    ingredient = _gunPrefabs.plantIngredient3;
                    break;
            }
        }

        if (key == KeyType.B) {
            switch (ingredientVersion) {
                case 1:
                    ingredient = _gunPrefabs.boneIngredient1;
                    break;
                case 2:
                    ingredient = _gunPrefabs.boneIngredient2;
                    break;
                default:
                    ingredient = _gunPrefabs.boneIngredient3;
                    break;
            }
        }

        if (key == KeyType.C) {
            switch (ingredientVersion) {
                case 1:
                    ingredient = _gunPrefabs.mineralIngredient1;
                    break;
                case 2:
                    ingredient = _gunPrefabs.mineralIngredient2;
                    break;
                default:
                    ingredient = _gunPrefabs.mineralIngredient3;
                    break;
            }
        }

        if (key == KeyType.D) {
            switch (ingredientVersion) {
                case 1:
                    ingredient = _gunPrefabs.fluidIngredient1;
                    break;
                case 2:
                    ingredient = _gunPrefabs.fluidIngredient2;
                    break;
                default:
                    ingredient = _gunPrefabs.fluidIngredient3;
                    break;
            }
        }

        if (ingredient != null) {
            Instantiate(ingredient);
        }
    }

    KeyType DetectKeyPressed() {
        var keyPressed = KeyType.Unknown;

        if (Controller.GetKeyDown(Preferences.Instance.getKeyCode(KeyType.A))) {
            keyPressed = KeyType.A;
        }

        if (Controller.GetKeyDown(Preferences.Instance.getKeyCode(KeyType.B))) {
            keyPressed = KeyType.B;
        }

        if (Controller.GetKeyDown(Preferences.Instance.getKeyCode(KeyType.C))) {
            keyPressed = KeyType.C;
        }

        if (Controller.GetKeyDown(Preferences.Instance.getKeyCode(KeyType.D))) {
            keyPressed = KeyType.D;
        }

        return keyPressed;
    }

    void TrackKeys() {
        if (EnemyHealth.Instance.currentHealth <= 0) { return; }

        var keyToAdd = DetectKeyPressed();

        if (keyToAdd == KeyType.Unknown) { return; }

        if (_keys.Count < _keyCapacity) {
            _keys.Add(keyToAdd);

            OpenCauldron();
            SpawnIngredient(keyToAdd);
            _cannonContentsDisplay.AddIconByKeyType(keyToAdd);
        }
        else {
            _cannonContentsDisplay.IndicateFull();
            Invoke("SetIdle", 0.4f);
        }
    }

    void QueueAction()
    {
        if (_actionInQueue) { return; }

        foreach (var keySequence in _keySequences)
        {
            if (keySequence.Check(_keys))
            {
                Invoke("CloseCauldron", 0.4f);

                _actionInQueue = true;
                _currentDelay = 0;
                _actionName = keySequence.name;

                // now an action has been triggered, reset keys
                _keys = new List<KeyType>();
                _cannonContentsDisplay.ClearIcons(false, true);
            }
        }

        // action is not in queue, no valid combo detected
        if (!_actionInQueue)
        {
            _keys = new List<KeyType>();
            Instantiate(_gunPrefabs.smoke);
            _cannonContentsDisplay.ClearIcons();

            SetIdle();
        }
    }

    void TriggerAction()
    {
        if (_actionInQueue)
        {
            _currentDelay += Time.deltaTime;
            if (_currentDelay > _delayActionBy)
            {
                var attackWith = Element.Unknown;
                var baseDamage = 0;

                switch (_actionName)
                {
                    case "Bone Bullet":
                        Instantiate(_gunPrefabs.boneBullet);
                        Instantiate(_gunPrefabs.fluidParticles);

                        attackWith = Element.Bone;
                        baseDamage = 2;
                        break;
                    case "Plant Bullet":
                        Instantiate(_gunPrefabs.plantBullet);
                        Instantiate(_gunPrefabs.boneParticles);

                        attackWith = Element.Plant;
                        baseDamage = 2;
                        break;
                    case "Mineral Bullet":
                        Instantiate(_gunPrefabs.mineralBullet);
                        Instantiate(_gunPrefabs.plantParticles);

                        attackWith = Element.Mineral;
                        baseDamage = 2;
                        break;
                    case "Fluid Bullet":
                        Instantiate(_gunPrefabs.fluidBullet);
                        Instantiate(_gunPrefabs.mineralParticles);

                        attackWith = Element.Fluid;
                        baseDamage = 2;
                        break;
                    case "Bone Machine Gun":
                        Instantiate(_gunPrefabs.boneMachineGun);
                        Instantiate(_gunPrefabs.mineralParticles);

                        attackWith = Element.Bone;
                        baseDamage = 4;
                        break;
                    case "Plant Machine Gun":
                        Instantiate(_gunPrefabs.plantMachineGun);
                        Instantiate(_gunPrefabs.boneParticles);

                        attackWith = Element.Plant;
                        baseDamage = 4;
                        break;
                    case "Mineral Machine Gun":
                        Instantiate(_gunPrefabs.mineralMachineGun);
                        Instantiate(_gunPrefabs.fluidParticles);

                        attackWith = Element.Mineral;
                        baseDamage = 4;
                        break;
                    case "Fluid Machine Gun":
                        Instantiate(_gunPrefabs.fluidMachineGun);
                        Instantiate(_gunPrefabs.boneParticles);

                        attackWith = Element.Fluid;
                        baseDamage = 4;
                        break;
                    case "Bone Fire":
                        Instantiate(_gunPrefabs.boneFire);
                        Instantiate(_gunPrefabs.fluidCrazyParticles);

                        attackWith = Element.Bone;
                        baseDamage = 6;
                        break;
                    case "Plant Fire":
                        Instantiate(_gunPrefabs.plantFire);
                        Instantiate(_gunPrefabs.mineralCrazyParticles);

                        attackWith = Element.Plant;
                        baseDamage = 6;
                        break;
                    case "Mineral Fire":
                        Instantiate(_gunPrefabs.mineralFire);
                        Instantiate(_gunPrefabs.boneCrazyParticles);

                        attackWith = Element.Mineral;
                        baseDamage = 6;
                        break;
                    case "Fluid Fire":
                        Instantiate(_gunPrefabs.fluidFire);
                        Instantiate(_gunPrefabs.plantCrazyParticles);

                        attackWith = Element.Fluid;
                        baseDamage = 6;
                        break;
                    default:
                        break;
                }

                if (attackWith != Element.Unknown && baseDamage > 0)
                {
                    _enemyStatsTracker.ReduceEnemyHealth(attackWith, baseDamage);
                }

                _actionInQueue = false;
                _currentDelay = 0;
                _actionName = string.Empty;
            }
        }
    }

    void Update()
    {
        TrackKeys();

        // if trigger pulled
        if (_keys.Count > 0 && Controller.GetKeyDown(Preferences.Instance.getKeyCode(KeyType.Trigger))) {
            QueueAction();
        }

        TriggerAction();

        _enemyStatsTracker.RespawnEnemyIfDead();
    }

    #region - Animations -

    void SetIdle()
    {
        _barrel.Play("idle");
        _barrel.speed = 0;

        _cauldron.Play("idle");
        _cauldron.speed = 0;
    }

    void OpenCauldron()
    {
        _barrel.Play("fire", -1, 0.2f);
        _barrel.speed = 0;

        _cauldron.Play("open", -1, 0.2f);
        _cauldron.speed = 0;
    }

    void CloseCauldron()
    {
        _barrel.speed = 1;
        _cauldron.speed = 1;
    }

    #endregion
}
