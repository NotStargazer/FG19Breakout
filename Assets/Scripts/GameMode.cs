using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[Serializable]
public class GameModeIntEvent : UnityEvent<int>
{

}

public class GameMode : MonoBehaviour
{
    public static GameMode instance;
    public GameObject ballPrefab;

    private int ballsInPlay;
    private int starsInPlay;

    public int winSceneIndex;
    public int loseSceneIndex;

    public GameModeIntEvent onBallsChanged;
    public GameModeIntEvent onStarsChanged;

    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void OnBallAdded()
    {
        ballsInPlay++;
        onBallsChanged.Invoke(ballsInPlay);
    }
    public void OnBallRemoved()
    {
        ballsInPlay--;
        onBallsChanged.Invoke(ballsInPlay);
        if (ballsInPlay <= 0)
        {
            Cursor.visible = true;
            SceneLoader.instance.LoadScene(loseSceneIndex, LoadSceneMode.Additive);
        }
    }

    public void OnStarsAdded()
    {
        starsInPlay++;
        onStarsChanged.Invoke(starsInPlay);
    }

    public void OnStarsRemoved()
    {
        starsInPlay--;
        onStarsChanged.Invoke(starsInPlay);
        if (starsInPlay <= 0)
        {
            Cursor.visible = true;
            SceneLoader.instance.LoadScene(winSceneIndex, LoadSceneMode.Additive);
        }
    }
}
