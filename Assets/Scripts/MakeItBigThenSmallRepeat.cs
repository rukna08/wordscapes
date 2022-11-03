using TMPro;
using UnityEngine;

public class MakeItBigThenSmallRepeat : MonoBehaviour {

    public TextMeshProUGUI scoreTextDisplay;

    float amount = 1f;

    void Update() {
        if (scoreTextDisplay.fontSize >= 100f) {
            amount *= -1f;
        }

        if (scoreTextDisplay.fontSize <= 20f) {
            amount *= -1f;
        }

        scoreTextDisplay.fontSize += amount;

        Debug.Log(scoreTextDisplay.fontSize);
    }
}
