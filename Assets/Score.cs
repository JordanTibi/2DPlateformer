using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI _text;

    int _score;

    public void AddScore(int scoreToAdd)
    {
        Debug.Log("Youpi c'est gagné");

        _score += scoreToAdd;
        _text.text = _score.ToString();
    }

}
