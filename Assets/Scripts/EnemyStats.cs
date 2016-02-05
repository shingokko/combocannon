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

	public int getDamage(Element attackE, int basicDamage){
		int damage = basicDamage;

		switch((int)elem){
			case 0:
				if((int)attackE == 1){
					damage += 1;
					changeInfo(1, damage);
				}else if((int)attackE == 3){
					damage -= 1;
					changeInfo(2, damage);
				}else{
					changeInfo(3, damage);
				}
				break;

			case 1:
				if((int)attackE == 2){
					damage += 1;
					changeInfo(1, damage);
				}else if((int)attackE == 0){
					damage -= 1;
					changeInfo(2, damage);
				}else{
					changeInfo(3, damage);
				}
				break;

			case 2:
				if((int)attackE == 3){
					damage += 1;
					changeInfo(1, damage);
				}else if((int)attackE == 1){
					damage -= 1;
					changeInfo(2, damage);
				}else{
					changeInfo(3, damage);
				}
				break;
			case 3:
				if((int)attackE == 0){
					damage += 1;
					changeInfo(1, damage);
				}else if((int)attackE == 2){
					damage -= 1;
					changeInfo(2, damage);
				}else{
					changeInfo(3, damage);
				}
				break;
			case 4:
				changeInfo(3, damage);
				break;
		}

		return damage;
	}

	public void changeInfo(int cond, int damagePoint){

		switch(cond){
			case 1:
				ElementEffect.Instance.info = "Critical Hit";
				ElementEffect.Instance.textColor = new Color(200,0,0);
				break;
			case 2:
				ElementEffect.Instance.info = "";
				ElementEffect.Instance.textColor = new Color(140, 0, 120);
				
				break;
			case 3:
				ElementEffect.Instance.info = "";
				ElementEffect.Instance.textColor = new Color(255, 255, 255);
				
				break;
			
		}

		
		ElementEffect.Instance.effectchanged = true;
		ElementEffect.Instance.damagechanged = true;
		ElementEffect.Instance.enemyDamage = "- " + damagePoint;
	}


}
