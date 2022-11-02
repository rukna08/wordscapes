using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    
    #region PUBLIC VARIABLES

    public string[] level0_texts;
    public TextMeshProUGUI[] toBeDisplayedTexts;
    public TMP_InputField inputField;
    
    #endregion

    #region PRIVATE VARIABLES
    
    private bool[] level0TextsSecretValues;
    
    #endregion

    void Start() {
        level0TextsSecretValues = new bool[level0_texts.Length];

        SetSecretValueToFalse();
    }

    void Update() {
        for(int i = 0; i < level0_texts.Length; i++) {
            if(inputField.text == level0_texts[i]) {
                SetHiddenTextToDisplayText(i);
                SetSecretValueToTrue(i);
            }
        }

        if(CheckIfSecretValuesAreTrue()) {
            Debug.Log("You win!");
        }
    }

    #region FUNCTIONS

    void SetHiddenTextToDisplayText(int index) {
        toBeDisplayedTexts[index].SetText(level0_texts[index]);
    }

    void SetSecretValueToTrue(int index) {
        level0TextsSecretValues[index] = true;
    }

    void SetSecretValueToFalse() {
        for(int i = 0; i < level0TextsSecretValues.Length; i++) {
            level0TextsSecretValues[i] = false;
        }
    }

    bool CheckIfSecretValuesAreTrue() {
        for(int i = 0; i < level0TextsSecretValues.Length; i++) {
            if(level0TextsSecretValues[i] == false) {
                return false;
            }
        }

        return true;
    }

    #endregion

    
}