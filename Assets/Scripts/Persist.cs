using UnityEngine;
using UnityEngine.SceneManagement;

public class Persist : MonoBehaviour {

    void Start() {
        DontDestroyOnLoad(gameObject);
    }

    void Update() {
        if (SceneManager.GetActiveScene().buildIndex > 10) {
            Destroy(gameObject);
        }
    }
}
