using UnityEngine;
using System.Collections.Generic;

public class KeySequence
{
	public string name;
    KeyType[] _keys;

    public KeySequence(string name, KeyType[] keys) {
    	this.name = name;
        _keys = keys;
    }

    public bool CheckSoFar(IList<KeyType> keys) {
        if (keys.Count == 0 || _keys.Length == 0) { return false; }

        for (var index = 0; index < keys.Count; index++) {
            var key = keys[index];

            if (index <= (_keys.Length - 1)) {
                if (key != _keys[index]) {
                    return false;
                }
            }
        }

        return true;
    }

    public bool Check(IList<KeyType> keys) {
        if (keys.Count == 0 || _keys.Length == 0 || keys.Count != _keys.Length) { return false; }

        for (var index = 0; index < keys.Count; index++) {
            var key = keys[index];

            if (index <= (_keys.Length - 1)) {
                if (key != _keys[index]) {
                    return false;
                }
            }
        }

        return true;
    }
}