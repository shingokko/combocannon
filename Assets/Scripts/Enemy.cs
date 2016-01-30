using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	private int counter = 0;
	
	// Use this for initialization
	void Start () {
		EnemyHealth .Instance.currentHealth = 10;
		counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (EnemyHealth.Instance.currentHealth == 0){
			Destroy(gameObject);
			counter = 0;
		}else if(PlayerHealth.Instance.currentHealth == 0){
			transform.localScale = new Vector3(0.48563f, 0.48563f,0.48563f);
			counter = 0;
		}else{
			transform.localScale += new Vector3(0.00167f, 0.00167f,0.00167f);
			counter += 1;
		}

		if(counter == 300 && PlayerHealth.Instance.currentHealth != 0){
			PlayerHealth.Instance.currentHealth -= 2;
			counter = 0;
			transform.localScale = new Vector3(0.48563f, 0.48563f,0.48563f);
		}
	}
}
