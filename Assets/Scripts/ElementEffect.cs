using UnityEngine;
using System.Collections;

public class ElementEffect : Singleton<ElementEffect> {

	public string info = "";
	public Color textColor = new Color(255, 255, 255);
	
	public bool effectchanged = false;
	public bool damagechanged = false;
	public bool playerDamageChanged = false;

	public string enemyDamage = "";
	public string playerDamage = "";

	public ElementEffect(){

	}
}
