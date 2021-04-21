using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    [SerializeField]
    private Text Score;
    private float _score = 0;
    [SerializeField]
    private bool _pause = true;
    public void IncrementScore()
    {
        _score++;
    }
    public void DecrementScore()
    {
        _score--;
    }
    public void Pause()
    {
        _pause = !_pause;
        if (_pause)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Score.text = _score.ToString();
    }
}
