using UnityEngine;
using System.Collections.Generic;

public class KeySequence
{
    public Element Primary;
    public Element Secondary;
	public string name;
    KeyType[] _keys;

    public KeySequence(string name, KeyType[] keys, Element prim, Element sec) {
    	this.name = name;
        _keys = keys;
        Primary = prim;
        Secondary = sec;

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

    /*
    calculates a running total of Life and Nature as determined on the input ingredients.
    The following weighting is given to each input ingredient:    
                    Life    |   Nature
    Bone        |     -1    |     +1
    Mineral     |     -1    |     -1
    Fluid       |     +1    |     -1
    Plant       |     +1    |     +1

    The running totals are then matched to these same distributions to determine what the overall element of the attack is.

    */
    private Element calculateAttackType() {
        int Nature = 0;
        int Life = 0;
        for (int i = 0; i < _keys.Length; i++) {
            switch(convertKeyTypeToElement(_keys[i])) {
                case Element.Plant:
                    Life++;
                    Nature++;
                    break;
                case Element.Bone:
                    Life--;
                    Nature++;
                    break;
                case Element.Mineral:
                    Life--;
                    Nature--;
                    break;
                case Element.Fluid:
                    Life++;
                    Nature--;
                    break;
                default:
                    break;
            }
        }
        if (Life > 0 && Nature > 0) {
            return Element.Plant;
        } else if (Life > 0 && Nature < 0) {
            return Element.Fluid;
        } else if (Life < 0 && Nature > 0) {
            return Element.Bone;
        } else {
            return Element.Mineral;
        }
    }

    private Element convertKeyTypeToElement(KeyType type) {
        switch(type) {
            case KeyType.A:
                return Element.Plant;
            case KeyType.B:
                return Element.Bone;
            case KeyType.C:
                return Element.Mineral;
            case KeyType.D:
                return Element.Fluid;
            default:    //Primarily applied to trigger keytype
                return Element.Unknown;
        }

    }
}