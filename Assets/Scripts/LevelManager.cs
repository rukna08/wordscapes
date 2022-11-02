using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    
    #region PUBLIC VARIABLES

    public string[] level_texts;
    public TextMeshProUGUI[] toBeDisplayedTexts;
    public TMP_InputField inputField;
    
    #endregion

    #region PRIVATE VARIABLES
    
    private bool[] levelTextsSecretValues;
    
    #endregion

    void Start() {
        levelTextsSecretValues = new bool[level_texts.Length];

        SetSecretValueToFalse();
    }

    void Update() {
        for(int i = 0; i < level_texts.Length; i++) {
            if(inputField.text == level_texts[i]) {
                SetHiddenTextToDisplayText(i);
                SetSecretValueToTrue(i);
            }
        }

        if(CheckIfSecretValuesAreTrue()) {
            Debug.Log("You win!");

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    #region FUNCTIONS

    void SetHiddenTextToDisplayText(int index) {
        toBeDisplayedTexts[index].SetText(level_texts[index]);
    }

    void SetSecretValueToTrue(int index) {
        levelTextsSecretValues[index] = true;
    }

    void SetSecretValueToFalse() {
        for(int i = 0; i < levelTextsSecretValues.Length; i++) {
            levelTextsSecretValues[i] = false;
        }
    }

    bool CheckIfSecretValuesAreTrue() {
        for(int i = 0; i < levelTextsSecretValues.Length; i++) {
            if(levelTextsSecretValues[i] == false) {
                return false;
            }
        }

        return true;
    }

    #endregion
    
}