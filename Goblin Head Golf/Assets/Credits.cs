using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public GameObject body;
    public GameObject scorePanel;

    private void Start()
    {
        FindObjectOfType<ScorePanel>().SetPanel(FindObjectOfType<LevelController>().GetTotalScoreInt());
        StartCoroutine(BodyDrop());
    }
    IEnumerator BodyDrop()
    {
        var bodies = FindObjectOfType<LevelController>().GetTotalScoreInt();

        while(bodies > 0)
        {
            Instantiate(body, transform.position, Quaternion.Euler(0f, 0f, Random.Range(0f, 359f)));
            bodies--;
            yield return new WaitForSeconds(Random.Range(0.1f, 0.4f));

        }
    }
}
