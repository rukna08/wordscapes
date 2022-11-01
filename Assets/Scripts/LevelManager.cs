using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public string[] level0_texts;

    public TextMeshProUGUI[] toBeDisplayedTexts;

    public TMP_InputField inputField;

    void Update() {
        for(int i = 0; i < level0_texts.Length; i++) {
            if(inputField.text == level0_texts[i]) {
                SetHiddenTextToDisplayText(i);
            }
        }
    }

    void SetHiddenTextToDisplayText(int index) {
        toBeDisplayedTexts[index].SetText(level0_texts[index]);
    }
}