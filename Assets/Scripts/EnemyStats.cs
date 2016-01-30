using UnityEngine;
using System.Collections;

public class EnemyStats {
	private int health;

	public  EnemyStats(int hp){
		health = hp;
	}

	public int getHealth(){
		return health;
	}


}
