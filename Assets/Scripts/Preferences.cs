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
				"Bone Bullet", new KeyType[] { KeyType.B, KeyType.B, KeyType.Trigger }, Element.Bone, Element.Bone
			),

			new KeySequence
			(
				"Plant Bullet", new KeyType[] { KeyType.B, KeyType.A, KeyType.Trigger }, Element.Bone, Element.Plant
			),

			new KeySequence
			(
				"Fluid Bullet", new KeyType[] { KeyType.B, KeyType.D, KeyType.Trigger }, Element.Bone, Element.Fluid
			),

			new KeySequence
			(
				"Mineral Bullet", new KeyType[] { KeyType.B, KeyType.C, KeyType.Trigger},  Element.Bone, Element.Mineral
			),
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
