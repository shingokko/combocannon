using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class FlashingArrow : MonoBehaviour {
	public GameObject Link;
	public int period = 10;
	private int count = 0;
	private bool flash = true;

	public Renderer rend;
    
    void Start() {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

	void Update() {
		if (Link.GetComponent<ConfigKeyInput>().selected) {
			count = (count + 1) % period;
			if (count == 0) {
				rend.enabled = !rend.enabled;
			}
		} else {
			if (!rend.enabled) {
				rend.enabled = true;
			}
		}
	}



}