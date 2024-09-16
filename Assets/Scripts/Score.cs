using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score;

    public Text text;
    public void AddScore()
    {
        score++;
        text.text = score.ToString();
    }
}
