using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{
    public void PlayRound()
    {
        SceneManager.LoadScene(1);
    }

    public void DrivingRange()
    {
        SceneManager.LoadScene(12);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
