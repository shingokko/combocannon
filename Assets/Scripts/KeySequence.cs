using UnityEngine;
using System.Collections.Generic;

public class KeySequence
{
    float _allowedTime = 0.3f;
    IList<KeyType> _keys;

    public KeySequence(IList<KeyType> keys) {
        _keys = keys;
    }
}