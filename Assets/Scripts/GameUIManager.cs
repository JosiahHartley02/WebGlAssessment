using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    [SerializeField]
    private Text Score;
    private float _score = 0;
    public void IncrementScore()
    {
        _score++;
    }
    public void DecrementScore()
    {
        _score--;
    }
    // Update is called once per frame
    void Update()
    {
        Score.text = _score.ToString();
    }
}
