using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ParticleSystem))]
public class Explosion : MonoBehaviour {
    float _currentTime;
    float _waitTime = 0.6f;
    ParticleSystem _particleSystem;

    void Start() {
        _currentTime = 0;
        _particleSystem = GetComponent<ParticleSystem>();
    }

    void Update () {
        _currentTime += Time.deltaTime;
        if (_currentTime > _waitTime) {
            _particleSystem.Stop();
            Destroy(gameObject, 0.1f);
        }
    }
}
