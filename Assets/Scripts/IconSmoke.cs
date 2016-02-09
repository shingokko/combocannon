using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class IconSmoke : MonoBehaviour {
    float _currentTime;
    float _waitTime = 2.5f;
    GameObject _target;
    Animator _animator;

    void Start() {
        _currentTime = 0;
        _animator = GetComponent<Animator>();
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
