using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController instance;

    public int hole1score = 0;
    public int hole2score = 0;
    public int hole3score = 0;
    public int hole4score = 0;
    public int hole5score = 0;
    public int hole6score = 0;
    public int hole7score = 0;
    public int hole8score = 0;
    public int hole9score = 0;

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
    }

}
