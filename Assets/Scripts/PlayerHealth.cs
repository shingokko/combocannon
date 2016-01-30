using UnityEngine;
using System.Collections;

public class PlayerHealth : Singleton<PlayerHealth> {

	public int maxHealth = 10;
	public int currentHealth = 10;
	public float shake = 0;
}
