using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    //A reference to the score output display
    [SerializeField]
    private Text Score;
    //The variable that actually keeps track of the score
    private float _score = 0;
    //The variable that keeps track of whether or not to pause the game
    [SerializeField]
    private bool _pause = true;

    //Adds a point to the score
    public void IncrementScore()
    {
        _score++;
    }
    //Subtracts a point from the score
    public void DecrementScore()
    {
        _score--;
    }
    //Toggles pause, and then sets the time scale to match
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
        //Updates the score so that is always displaying fresh information
        Score.text = _score.ToString();
    }
}
