using System.IO;

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
    public GameObject nextLevelButton;
    
    #endregion

    #region PRIVATE VARIABLES
    
    private bool[] levelTextsSecretValues;
    private static int score;
    private static List<string> unlockedTexts;
    private BinaryWriter binaryWriter;

    #endregion

    #region START & UPDATE

    void Start() {
        Init();
    }

    void Update() {
        UnlockIfEnterKeyPressedAndDisplayScore();

        LoadNextScene();

        PressEscToQuit();
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
        if (CheckIfSecretValuesAreTrue() && SceneManager.GetActiveScene().buildIndex == 10) {
            OutputScoreToBinaryFile();

            if (score > 0) {
                SceneManager.LoadScene("levelgameovernice");
            } else {
                SceneManager.LoadScene("levelgameoveroffensive");
            }
            
            return;
        }

        if (CheckIfSecretValuesAreTrue()) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("Next scene loaded!");
        }
    }

    void PressEscToQuit() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }

    public void LoadNextSceneByNextButtonNegativeTen() {
        score -= 10;

        SetAllSecretValuesToTrue();
    }

    void SetAllSecretValuesToTrue() {
        for (int i = 0; i < levelTextsSecretValues.Length; i++) {
            levelTextsSecretValues[i] = true;
        }
    }

    void OutputScoreToBinaryFile() {
        binaryWriter = new BinaryWriter(new FileStream("scoredata", FileMode.Create));
        binaryWriter.Write(score);
        binaryWriter.Close();
    }

    #endregion
}