using UnityEngine;
using System.Collections;

public class EnemyHealthBar : MonoBehaviour {

	TextMesh textMesh;

	// Use this for initialization
	void Start () {
		textMesh = GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
		textMesh.text = EnemyHealth.Instance.currentHealth + " / " + EnemyHealth.Instance.maxHealth;
	}

}
