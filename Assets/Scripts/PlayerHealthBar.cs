using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerHealthBar : MonoBehaviour {

	TextMesh textMesh;
	private int counter;

	void Start () {
		textMesh = GetComponent<TextMesh>();
		counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		textMesh.text = PlayerHealth.Instance.currentHealth + " / " + PlayerHealth.Instance.maxHealth;

		if (PlayerHealth.Instance.currentHealth <= 0){
			counter += 1;
			if(counter >= 100){
				SceneManager.LoadScene("GameOver");	
			}
					
		}
	}
}
