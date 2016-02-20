using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerHealthBar : MonoBehaviour {

	TextMesh textMesh;
	private int counter;
	private int damageCounter;
	private int currentHealth;
	private int lastHealth;

	void Start () {
		textMesh = GetComponent<TextMesh>();
		counter = 0;
		damageCounter = 0;
		lastHealth = 0;
		currentHealth = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(PlayerHealth.Instance.currentHealth < lastHealth){
			damageCounter += 1;
			currentHealth = lastHealth;
			if(damageCounter % 5 == 0){
				currentHealth -= 1;
				textMesh.text = currentHealth + " / " + PlayerHealth.Instance.maxHealth;
				lastHealth -= 1;
			}
			
		}else{
			textMesh.text = PlayerHealth.Instance.currentHealth + " / " + PlayerHealth.Instance.maxHealth;
			lastHealth = PlayerHealth.Instance.currentHealth;
			damageCounter = 0;
		}
		
		textMesh.text = PlayerHealth.Instance.currentHealth + " / " + PlayerHealth.Instance.maxHealth;

		if (PlayerHealth.Instance.currentHealth <= 0){
			counter += 1;
			if(counter >= 100){
				SceneManager.LoadScene("GameOver");	
			}
					
		}
	}
}
