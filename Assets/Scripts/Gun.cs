using UnityEngine;
using System.Collections.Generic;

public class Gun : MonoBehaviour {
	float _timeLimit = 2;
	IList<KeyType> keys;

	void Start () {
		ResetKeys();
	}
	
	void ResetKeys() {
		keys = new List<KeyType>();
	}

	void Update () {

	}
}
