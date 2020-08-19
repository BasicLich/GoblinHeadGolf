using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class ScorePanel : MonoBehaviour
{
    public TextMeshProUGUI topText;

    public TextMeshProUGUI scoreHole1;
    public TextMeshProUGUI toParHole1;

    public TextMeshProUGUI scoreHole2;
    public TextMeshProUGUI toParHole2;

    public TextMeshProUGUI scoreHole3;
    public TextMeshProUGUI toParHole3;

    public TextMeshProUGUI scoreHole4;
    public TextMeshProUGUI toParHole4;

    public TextMeshProUGUI scoreHole5;
    public TextMeshProUGUI toParHole5;

    public TextMeshProUGUI scoreHole6;
    public TextMeshProUGUI toParHole6;

    public TextMeshProUGUI scoreHole7;
    public TextMeshProUGUI toParHole7;

    public TextMeshProUGUI scoreHole8;
    public TextMeshProUGUI toParHole8;

    public TextMeshProUGUI scoreHole9;
    public TextMeshProUGUI toParHole9;

    public TextMeshProUGUI totalScore;
    public TextMeshProUGUI totalToPar;

    private LevelController levelCont;
    private void Awake()
    {
        levelCont = LevelController.instance;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            levelCont.currentHole++;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    public void SetPanel(int points)
    {
        var holeInOne = false;
        var toPar = points - levelCont.pars[levelCont.currentHole];
        levelCont.scores[levelCont.currentHole] = points;

        if(points == 1)
        {
            holeInOne = true;
        }

        if(toPar < 5 && !holeInOne)
        {
            switch(toPar)
            {
                case -3:
                    topText.text = "Albatross";
                    break;
                case -2:
                    topText.text = "Eagle";
                    break;
                case -1:
                    topText.text = "Birdie";
                    break;
                case 0:
                    topText.text = "Par";
                    break;
                case 1:
                    topText.text = "Bogey";
                    break;
                case 2:
                    topText.text = "Double-Bogey";
                    break;
                case 3:
                    topText.text = "Triple-Bogey";
                    break;
                case 4:
                    topText.text = "Quadruple-Bogey";
                    break;
            }
        } else
        {
            topText.text = "+" + toPar.ToString();
        }

        if(holeInOne)
        {
            topText.text = "HOLE IN ONE!";
        }

        // Holes

        scoreHole1.text = levelCont.GetHoleScore(0);
        scoreHole2.text = levelCont.GetHoleScore(1);
        scoreHole3.text = levelCont.GetHoleScore(2);
        scoreHole4.text = levelCont.GetHoleScore(3);
        scoreHole5.text = levelCont.GetHoleScore(4);
        scoreHole6.text = levelCont.GetHoleScore(5);
        scoreHole7.text = levelCont.GetHoleScore(6);
        scoreHole8.text = levelCont.GetHoleScore(7);
        scoreHole9.text = levelCont.GetHoleScore(8);

        toParHole1.text = levelCont.GetToPar(0);
        toParHole2.text = levelCont.GetToPar(1);
        toParHole3.text = levelCont.GetToPar(2);
        toParHole4.text = levelCont.GetToPar(3);
        toParHole5.text = levelCont.GetToPar(4);
        toParHole6.text = levelCont.GetToPar(5);
        toParHole7.text = levelCont.GetToPar(6);
        toParHole8.text = levelCont.GetToPar(7);
        toParHole9.text = levelCont.GetToPar(8);

        totalScore.text = levelCont.GetTotalScore();
        totalToPar.text = levelCont.GetTotalToPar();
    }
}
