﻿using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public float moveSpeed = 30;

    bool _dead;
    GameObject _origin;
    GameObject _target;
    Vector3 _destination;

    void Start () {
        _origin = GameObject.Find("GunTip");
        _target = GameObject.Find("EnemyHead");
        _dead = false;
        transform.position = _origin.transform.position;

        _destination = new Vector3
        (
            _target.transform.position.x,
            _target.transform.position.y,
            _target.transform.position.z
        );

        EnsureDestination();
    }

    bool V3Equal(Vector3 a, Vector3 b) {
        return Vector3.SqrMagnitude(a - b) < 0.0001;
    }

    void EnsureDestination() {
        if (_target == null) {
            _dead = true;

            if (gameObject != null) {
                Destroy(gameObject, 0.1f);
            }
        }
    }

    void Update () {
        if (_dead) { return; }

        EnsureDestination();

        var step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, _destination, step);
        if (V3Equal(transform.position, _destination)) {
            _dead = true;
            
            if (gameObject != null) {
                Destroy(gameObject, 0.1f);
            }
        }
    }
}
