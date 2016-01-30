using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

	GameObject enemy = null;
	public int respawnTime = 300;
	private int counter;

	void OnMouseDown() {
		if(EnemyHealth.Instance.currentHealth > 0){
			EnemyHealth.Instance.currentHealth -= 1;
		}
	}

	// Use this for initialization
	void Start () {
		enemy = (GameObject)Resources.Load("Enemy");
		Instantiate(enemy, new Vector3(-0.4325213f, 0.4685652f, 0), Quaternion.identity);
		EnemyHealth.Instance.currentHealth = 10;
		counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(EnemyHealth.Instance.currentHealth == 0){
			counter += 1;

			if(counter == respawnTime){
				enemy = (GameObject)Resources.Load("Enemy");
				Instantiate(enemy, new Vector3(-0.4325213f, 0.4685652f, 0), Quaternion.identity);
				counter = 0;
			}
			
		}
	}
}
