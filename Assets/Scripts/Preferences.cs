using UnityEngine;
using System.Collections;

public class Preferences : Singleton<Preferences> {

	public KeyCode UserInputA = KeyCode.A;
	public KeyCode UserInputB = KeyCode.S;
	public KeyCode UserInputC = KeyCode.D;
	public KeyCode UserInputD = KeyCode.F;
	public KeyCode UserInputTrigger = KeyCode.Space;

	protected Preferences(){}

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
