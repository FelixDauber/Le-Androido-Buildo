using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreHolder : MonoBehaviour
{
    public static ScoreHolder scoreHolder;
    private void Awake()
    {
        scoreHolder = this;
    }

    int points;
    public void AddPoint()
    {
        points++;
        if(points >= 4)
        {
            SceneManager.LoadScene(0);
        }
    }
}
