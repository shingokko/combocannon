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
				"Plant Bullet", new KeyType[] { KeyType.B, KeyType.A, KeyType.Trigger }, Element.Plant, Element.Bone
			),

			new KeySequence
			(
				"Fluid Bullet", new KeyType[] { KeyType.B, KeyType.D, KeyType.Trigger }, Element.Fluid, Element.Bone
			),

			new KeySequence
			(
				"Mineral Bullet", new KeyType[] { KeyType.B, KeyType.C, KeyType.Trigger},  Element.Bone, Element.Mineral
			),

			new KeySequence
			(
				"Bone Machine Gun", new KeyType[] { KeyType.B, KeyType.C, KeyType.B, KeyType.Trigger }, Element.Bone, Element.Bone
			),

			new KeySequence
			(
				"Plant Machine Gun", new KeyType[] { KeyType.A, KeyType.B, KeyType.A, KeyType.Trigger }, Element.Plant, Element.Bone
			),

			new KeySequence
			(
				"Fluid Machine Gun", new KeyType[] { KeyType.D, KeyType.C, KeyType.D, KeyType.Trigger }, Element.Fluid, Element.Bone
			),

			new KeySequence
			(
				"Mineral Machine Gun", new KeyType[] { KeyType.C, KeyType.B, KeyType.C, KeyType.Trigger }, Element.Mineral, Element.Bone
			),

			new KeySequence
			(
				"Bone Fire", new KeyType[] { KeyType.B, KeyType.B, KeyType.D, KeyType.D, KeyType.Trigger }, Element.Bone, Element.Fluid
			),

			new KeySequence
			(
				"Plant Fire", new KeyType[] { KeyType.A, KeyType.D, KeyType.D, KeyType.A, KeyType.Trigger }, Element.Plant, Element.Bone
			),

			new KeySequence
			(
				"Fluid Fire", new KeyType[] { KeyType.D, KeyType.D, KeyType.D, KeyType.A, KeyType.Trigger }, Element.Fluid, Element.Plant
			),

			new KeySequence
			(
				"Mineral Fire", new KeyType[] { KeyType.C, KeyType.A, KeyType.D, KeyType.B, KeyType.Trigger }, Element.Mineral, Element.Mineral
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
