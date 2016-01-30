using UnityEngine;
using System.Collections;

public class EnemyHealth : Singleton<EnemyHealth> {

	public int maxHealth;
	public int currentHealth;

	protected EnemyHealth(){
		maxHealth = 10;
		currentHealth = 10;
	}

	public void reset(){
		maxHealth = 10;
		currentHealth = 10;
	}
}
