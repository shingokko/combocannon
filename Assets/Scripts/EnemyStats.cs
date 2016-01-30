using UnityEngine;
using System.Collections;

public class EnemyStats {
	private int health;
	private Element elem;

	public  EnemyStats(int hp, Element e){
		health = hp;
		elem = e;
	}

	public int getHealth(){
		return health;
	}

	public int getDamage(Element attackE){
		int damage = 2;

		switch((int)elem){
			case 0:
				if((int)attackE == 1){
					damage += 1;
				}else if((int)attackE == 3){
					damage -= 1;
				}
				break;

			case 1:
				if((int)attackE == 2){
					damage += 1;
				}else if((int)attackE == 0){
					damage -= 1;
				}
				break;

			case 2:
				if((int)attackE == 3){
					damage += 1;
				}else if((int)attackE == 1){
					damage -= 1;
				}
				break;
			case 3:
				if((int)attackE == 0){
					damage += 1;
				}else if((int)attackE == 2){
					damage -= 1;
				}
				break;
			case 4:
				break;
		}

		return damage;
	}


}
