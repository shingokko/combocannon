using UnityEngine;
using System.Collections;

public class PlayerHealth : Singleton<PlayerHealth> {

	public int maxHealth = 20;
	public int currentHealth = 20;
	public float shake = 0;
}
