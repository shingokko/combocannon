using UnityEngine;

public class Ingredient : MonoBehaviour {
    void Start () {
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("Name1"), "time", 1.0f));
        Destroy(gameObject, 1.1f);
    }
     
}
