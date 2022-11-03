using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {
    
    #region PUBLIC VARIABLES

    public string[] level_texts;
    public TextMeshProUGUI[] toBeDisplayedTexts;
    public TMP_InputField inputField;
    public TextMeshProUGUI scoreTextActual;
    
    #endregion

    #region PRIVATE VARIABLES
    
    private bool[] levelTextsSecretValues;
    private static int score;
    private static List<string> unlockedTexts;

    #endregion

    #region START & UPDATE

    void Start() {
        Init();
    }

    void Update() {
        UnlockIfEnterKeyPressedAndDisplayScore();

        LoadNextScene();
    }

    #endregion

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

    void Init() {
        levelTextsSecretValues = new bool[level_texts.Length];
        SetSecretValueToFalse();
        scoreTextActual.SetText(score.ToString());
        unlockedTexts = new List<string>();
    }

    void UnlockIfEnterKeyPressedAndDisplayScore() {
        bool found = false;

        if (Input.GetKeyDown(KeyCode.Return)) {
            for (int i = 0; i < level_texts.Length; i++) {
                if (inputField.text == level_texts[i] && !unlockedTexts.Contains(level_texts[i])) {
                    SetHiddenTextToDisplayText(i);
                    SetSecretValueToTrue(i);
                    inputField.text = "";

                    found = true;

                    unlockedTexts.Add(level_texts[i]);
                }
            }

            if (found) {
                score++;
            } else {
                score--;
            }

            scoreTextActual.SetText(score.ToString());
        }
    }

    void LoadNextScene() {
        if (CheckIfSecretValuesAreTrue()) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("Next scene loaded!");
        }
    }

    #endregion

}