using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Score : MonoBehaviour
{
    private Text _text;
    private int _score = 0;

    private void Awake()
    {
        _text = GetComponent<Text>();

        _text.text = _score + "";
    }

    public void AddScore()
    {
        _score += 1;
        _text.text = _score + "";
    }
}
