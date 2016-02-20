using UnityEngine;
using System.Collections;

public class FireBall : MonoBehaviour {
    bool _dead;
    GameObject _origin;
    GameObject _target;
    Vector3 _destination;
    
    public float moveSpeed = 30;
    public GameObject explosionPrefab;

    void Start () {
        _origin = GameObject.Find("GunTip");
        _target = GameObject.Find("EnemyHead");
        _dead = false;
        transform.position = _origin.transform.position;

        var offsetX = ((float)Random.Range(-100, 100)) * 0.025f;
        var offsetY = ((float)Random.Range(-100, 100)) * 0.025f;
        _destination = new Vector3
        (
            _target.transform.position.x + offsetX,
            _target.transform.position.y + offsetY,
            _target.transform.position.z
        );

        EnsureTarget();
    }

    bool V3Equal(Vector3 a, Vector3 b) {
        return Vector3.SqrMagnitude(a - b) < 0.0001;
    }

    void EnsureTarget() {
        if (_target == null) {
            _dead = true;

            if (gameObject != null) {
                Destroy(gameObject, 0.1f);
            }
        }
    }

    void Update () {
        if (_dead) { return; }

        EnsureTarget();

        var step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, _destination, step);
        if (V3Equal(transform.position, _destination)) {
            _dead = true;

            Instantiate(explosionPrefab, _destination, Quaternion.identity);

            if (gameObject != null) {
                Destroy(gameObject, 0.1f);
            }
        }
    }
}
