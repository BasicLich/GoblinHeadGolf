using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController instance;

    public int[] scores;
    public int[] pars = { 3, 4, 1, 1, 1, 1, 1, 1, 1 };

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

    public string GetHoleScore(int hole)
    {
        var score = scores[hole];
        if(score == 0)
        {
            return "-";
        } else
        {
            return score.ToString();
        }
    }

    public string GetToPar(int hole)
    {
        var score = scores[hole];
        if (score == 0)
        {
            return "-";
        }
        else
        {
            return (score - pars[hole]).ToString(); 
        }
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

    public string GetTotalToPar()
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

        return (sumHoles - sumPars).ToString();
        
    }

}
