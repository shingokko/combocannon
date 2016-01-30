using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {
	//Status
	private int counter = 0;
	public int attackStats;

	//Actions bool
	private bool defeated;
	private bool stun;
	private bool attack;
	public int lifeLastF;

	public int attackSpeed;
	public int stunDamage;


	
	// Use this for initialization
	void Start () {
		defeated = false;
		stun = false;
		attack = false;

	}
	
	// Update is called once per frame
	void Update () {

		//Die / defeated
		if (EnemyHealth.Instance.currentHealth <= 0 && !defeated){
			counter = 0;
			defeated = true;
		}

		if (!stun && lifeLastF - EnemyHealth.Instance.currentHealth >= stunDamage){
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
			transform.position = new Vector3(-0.4325213f, 0, 0);
			transform.localScale = new Vector3(0.852808f, 0.852808f,0.852808f);
			counter = 0;
			stun = false;
			lifeLastF = EnemyHealth.Instance.currentHealth;
		}


		if(PlayerHealth.Instance.currentHealth == 0){
			transform.localScale = new Vector3(0.852808f, 0.852808f,0.852808f);
			counter = 0;
		}else{
			if(!attack && !defeated && !stun){
				transform.localScale += new Vector3(0.0012f, 0.0012f,0.0012f);	
			}
			counter += 1;
		}

		//Attack
		if(counter == attackSpeed - 100 && PlayerHealth.Instance.currentHealth != 0){
			attack = true;
			counter = 0;
		}
		if(counter == 50 && attack){
			transform.localScale = new Vector3(2f, 2f,2f);
			transform.position = new Vector3(0, -5f, 0);
			if(PlayerHealth.Instance.currentHealth - attackStats < 0){
				PlayerHealth.Instance.currentHealth = 0;
			}else{
				PlayerHealth.Instance.currentHealth -= attackStats;
			}

			
		}else if(counter == 100 && attack){
			attack = false;
			counter = 0;
			transform.localScale = new Vector3(0.852808f, 0.852808f,0.852808f);
			transform.position = new Vector3(-0.4325213f, 0, 0);
		}

		if(counter%150 == 0){
			lifeLastF = EnemyHealth.Instance.currentHealth;
		}
	}

	protected void die(){
		Destroy(gameObject);
		GameData.Instance.score += 100;
	}
}
