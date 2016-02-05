using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public abstract class Listable : MonoBehaviour {
	public virtual void setSelect(bool select) {}

	public virtual bool getSelect() {
		return false;
	}

}
