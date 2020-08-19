using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController instance;

    public int[] scores;
    public int[] pars = { 3, 4, 3, 5, 4, 5, 4, 3, 5 };

    public int currentHole = 0;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
            return;
        }

        DontDestroyOnLoad(this);
        
        scores = new int[9];

    }

    public int GetHoleScore(int hole)
    {
        return scores[hole];
    }

    public int GetToPar(int hole)
    {
        return scores[hole] - pars[hole];
    }

    public string GetTotalScore()
    {
        var sum = 0;
        for (int i = 0; i < scores.Length; i++)
        {
            sum += scores[i];
        }

        return sum.ToString();
    }

    public int GetTotalToPar()
    {
        var sumHoles = 0;
        for (int i = 0; i < scores.Length; i++)
        {
            sumHoles += scores[i];
        }

        var sumPars = 0;
        for (int i = 0; i < currentHole + 1; i++)
        {
            sumPars += pars[i];
        }

        return sumHoles - sumPars;
        
    }

    public int GetTotalScoreInt()
    {
        var sum = 0;
        for (int i = 0; i < scores.Length; i++)
        {
            sum += scores[i];
        }

        return sum;
    }

    public void Reset()
    {
        currentHole = 0;
        for (int i = 0; i < scores.Length; i++)
        {
            scores[i] = 0;
        }

    }

}
