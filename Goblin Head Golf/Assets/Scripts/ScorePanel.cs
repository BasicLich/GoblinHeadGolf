using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class ScorePanel : MonoBehaviour
{
    public TextMeshProUGUI topText;

    public TextMeshProUGUI totalScore;
    public TextMeshProUGUI totalToPar;

    public TextMeshProUGUI[] scoresHole;
    public TextMeshProUGUI[] scoresToPar;


    private LevelController levelCont;
    private void Awake()
    {
        levelCont = LevelController.instance;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(SceneManager.GetActiveScene().buildIndex == 10)
            {
                levelCont.Reset();
                SceneManager.LoadScene(0);
                return;
            }

            if (SceneManager.GetActiveScene().buildIndex == 9)
            {
                if (PlayerPrefs.GetInt("lowestScore") == 0)
                {
                    PlayerPrefs.SetInt("lowestScore", levelCont.GetTotalScoreInt());
                }

                if(levelCont.GetTotalScoreInt() < PlayerPrefs.GetInt("lowestScore"))
                {
                    PlayerPrefs.SetInt("lowestScore", levelCont.GetTotalScoreInt());
                }   
                SceneManager.LoadScene(10);
                return;
            }

            levelCont.currentHole++;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    public void SetPanel(int points)
    {
        if (SceneManager.GetActiveScene().buildIndex != 10)
        {
            var holeInOne = false;
            var toPar = points - levelCont.pars[levelCont.currentHole];
            levelCont.scores[levelCont.currentHole] = points;

            if (points == 1)
            {
                holeInOne = true;
            }

            if (toPar < 5 && !holeInOne)
            {
                switch (toPar)
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
            }
            else
            {
                topText.text = "+" + toPar.ToString();
            }

            if (holeInOne)
            {
                topText.text = "HOLE IN ONE!";
            }
        } else
        {
            topText.text = levelCont.GetTotalScore() + " Goblins perished";
        }


        // Holes

        for (int x = 0; x < scoresHole.Length; x++)
        {
            var score = levelCont.GetHoleScore(x);
            scoresHole[x].text = score.ToString();
            if (score == 0)
            {
                scoresHole[x].text = "-";
            }
        }

        for (int x = 0; x < levelCont.currentHole + 1; x++)
        {
            var score = levelCont.GetToPar(x);
            scoresToPar[x].text = score.ToString();
            if (score < 0)
            {
                scoresToPar[x].color = new Color32(230, 72, 46, 255);
            }
            if(score == 0)
            {
                scoresToPar[x].text = "E";
            }
            if (score > 0)
            {
                scoresToPar[x].text = "+" + score.ToString();
            }
        }

        var totToPar = levelCont.GetTotalToPar();
        totalToPar.text = totToPar.ToString();
        if(totToPar < 0)
        {
            totalToPar.color = new Color32(230, 72, 46, 255);
        }
        if(totToPar == 0)
        {
            totalToPar.text = "E";
        }

        totalScore.text = levelCont.GetTotalScore();



    }
}
