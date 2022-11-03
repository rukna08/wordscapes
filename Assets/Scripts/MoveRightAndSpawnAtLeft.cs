using UnityEngine;

public class MoveRightAndSpawnAtLeft : MonoBehaviour {
    void Update() {
        transform.position += new Vector3(.5f, 0f, 0f);

        if (transform.position.x > Screen.width + 250) {
            transform.position = new Vector2(-250f, transform.position.y);
        }
    }

}
