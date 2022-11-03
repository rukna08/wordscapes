using System.IO;

using TMPro;
using UnityEngine;

public class ScoreDisplayer : MonoBehaviour {
    public TextMeshProUGUI scoreTextDisplay;

    private BinaryReader binaryReader;

    int score;

    void Start() {
        binaryReader = new BinaryReader(new FileStream("scoredata", FileMode.Open));
        score = binaryReader.ReadInt32();
        binaryReader.Close();
        scoreTextDisplay.SetText(score.ToString());
    }
}
