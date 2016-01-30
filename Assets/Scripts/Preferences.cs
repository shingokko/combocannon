using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Preferences : Singleton<Preferences> {

	public KeyCode UserInputA = KeyCode.A;
	public KeyCode UserInputB = KeyCode.S;
	public KeyCode UserInputC = KeyCode.D;
	public KeyCode UserInputD = KeyCode.F;
	public KeyCode UserInputTrigger = KeyCode.Space;
	public IList<KeySequence> RecipeList;

	protected Preferences() {
		RecipeList = new List<KeySequence>
		{
			new KeySequence
			(
				"Action 1", new KeyType[] { KeyType.A, KeyType.B, KeyType.Trigger } // action 1
			),
			new KeySequence
			(
				"Action 2", new KeyType[] { KeyType.A, KeyType.B, KeyType.C, KeyType.Trigger } // action 2
			),
			new KeySequence
			(
				"Action 3", new KeyType[] { KeyType.A, KeyType.B, KeyType.C, KeyType.D, KeyType.Trigger } // action 3
			),
			new KeySequence
			(
				"Action 3", new KeyType[] { KeyType.A, KeyType.A, KeyType.A, KeyType.Trigger } // action 4
			)
		};

	}

	public KeyCode getKeyCode(KeyType forInput) {
		switch(forInput) {
			case KeyType.A:
				return UserInputA;
			case KeyType.B:
				return UserInputB;
			case KeyType.C:
				return UserInputC;
			case KeyType.D:
				return UserInputD;
			case KeyType.Trigger:
				return UserInputTrigger;
			default:
				return 0;
		}
	}

	public void setKeyCode(KeyType forInput, KeyCode newKeyCode) {
		switch(forInput) {
			case KeyType.A:
				UserInputA = newKeyCode;
				break;
			case KeyType.B:
				UserInputB = newKeyCode;
				break;
			case KeyType.C:
				UserInputC = newKeyCode;
				break;
			case KeyType.D:
				UserInputD = newKeyCode;
				break;
			case KeyType.Trigger:
				UserInputTrigger = newKeyCode;
				break;
			default:
				return;
		}
	}
}
