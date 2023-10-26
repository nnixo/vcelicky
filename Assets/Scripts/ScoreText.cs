using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{

    public Text scoreText;
    void Start()
    {
        scoreText = GetComponent<Text>();
        Data.onScoreChanged.AddListener(UpdateText);
    }

    void UpdateText()
    {
        scoreText.text ="Score: "+ Data.player.GetScore().ToString();
    }
}
