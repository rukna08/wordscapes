using UnityEngine;

public class Jitter : MonoBehaviour {
    
    void Update() {
        transform.position = new Vector2(Random.Range(-Screen.width, Screen.width), Random.Range(-Screen.height, Screen.height));
    }
}
