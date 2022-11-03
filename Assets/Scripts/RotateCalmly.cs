using UnityEngine;

public class RotateCalmly : MonoBehaviour {
    float speed = 15f;

    void Update() {
        transform.Rotate(new Vector3(0f, 0f, 1f) * speed * Time.deltaTime);

        if (transform.rotation.z > .1f) {
            speed *= -1f;
        }

        if (transform.rotation.z < -.1f) {
            speed *= -1f;
        }
    }
}