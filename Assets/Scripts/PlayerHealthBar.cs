using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerHealthBar : MonoBehaviour {

	TextMesh textMesh;

	void Start () {
		textMesh = GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
		textMesh.text = PlayerHealth.Instance.currentHealth + " / " + PlayerHealth.Instance.maxHealth;

		if (PlayerHealth.Instance.currentHealth == 0){
			SceneManager.LoadScene("GameOver");
		}
	}
}
