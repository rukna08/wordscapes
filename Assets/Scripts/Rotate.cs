using UnityEngine;

public class Rotate : MonoBehaviour {
    public float rotationSpeed;

    void Start() {
        if (transform.name == "NerdTextDisplay") {
            rotationSpeed = 69f;
        }

        if (transform.name == "NoobTextDisplay") {
            rotationSpeed = -600f;
        }
    }

    void Update() {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}
