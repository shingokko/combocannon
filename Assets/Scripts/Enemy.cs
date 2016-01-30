using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	//Status
	private int counter = 0;
	private bool defeated;
	private bool stun;
	private bool attack;
	private int attackTime = 300;
	private int lifeLastF;



	
	// Use this for initialization
	void Start () {
		EnemyHealth .Instance.currentHealth = 10;
		counter = 0;
		defeated = false;
		stun = false;
		attack = false;
		lifeLastF = 10;
	}
	
	// Update is called once per frame
	void Update () {

		//Die / defeated
		if (EnemyHealth.Instance.currentHealth == 0 && !defeated){
			counter = 0;
			defeated = true;
		}

		if (!stun && lifeLastF - EnemyHealth.Instance.currentHealth >= 3){
			stun = true;
			//Cancel Attack
			if(attack){
				attack = false;
			}
			counter = 0;
		}

		if(defeated && counter <= 50){
			if( counter % 4 < 2){
				transform.Translate(Vector3.left * 0.1f);
			}else{
				transform.Translate(Vector3.right * 0.1f);
			}	
		}else if(defeated && counter <= 70){
			//zoom out
			transform.localScale -= new Vector3(0.05f, 0.05f,0.05f);
		}else if(defeated && counter > 70){
			die();
		}

		//stun
		if(stun && !defeated && counter < 20){
			if( counter % 4 < 2){
				transform.Translate(Vector3.left * 0.1f);
			}else{
				transform.Translate(Vector3.right * 0.1f);
			}
		}else if(stun && !defeated && counter == 20){
			transform.localScale = new Vector3(0.48563f, 0.48563f,0.48563f);
			counter = 0;
			stun = false;
			lifeLastF = EnemyHealth.Instance.currentHealth;
		}


		if(PlayerHealth.Instance.currentHealth == 0){
			transform.localScale = new Vector3(0.48563f, 0.48563f,0.48563f);
			counter = 0;
		}else{
			if(!attack && !defeated && !stun){
				transform.localScale += new Vector3(0.00167f, 0.00167f,0.00167f);	
			}
			counter += 1;
		}

		//Attack
		if(counter == attackTime - 100 && PlayerHealth.Instance.currentHealth != 0){
			attack = true;
			counter = 0;
		}
		if(counter == 50 && attack){
			transform.localScale = new Vector3(1.3f, 1.3f,1.3f);
			PlayerHealth.Instance.currentHealth -= 2;
		}else if(counter == 100 && attack){
			attack = false;
			counter = 0;
			transform.localScale = new Vector3(0.48563f, 0.48563f,0.48563f);
		}

		if(counter%100 == 0){
			lifeLastF = EnemyHealth.Instance.currentHealth;
		}
	}

	private void die(){
		Destroy(gameObject);
	}
}
