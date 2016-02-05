using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

/*
Author: Arran
*/
public class FlashingArrow : MonoBehaviour {
	public Listable Link;
	public int period = 10; //How long the flash should last for. 10 is equivalent to 10 ticks on 10 ticks off
	private int count = 0;

	public Renderer rend;
    
    void Start() {
        rend = GetComponent<Renderer>();
        rend.enabled = false;
    }

	void Update() {
		if (Link.getSelect()) {
			count = (count + 1) % period;	
			if (count == 0) {
				rend.enabled = !rend.enabled; //every period the render is switched on and off
			}
		} else {
			if (rend.enabled) {
				rend.enabled = false;
			}
		}
	}



}