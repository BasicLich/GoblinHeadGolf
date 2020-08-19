using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    private float counter = 0f;
    private bool hasHoled = false;
    private void Awake()
    {
        GetComponent<TrailRenderer>().enabled = false;
    }

    public void EnableRenderer()
    {
        GetComponent<TrailRenderer>().enabled = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "flag")
        {
            counter += 1f * Time.deltaTime;
        }
       
    }

    private void Update()
    {
        if (counter >= 0.8f && !hasHoled)
        {
            hasHoled = true;
            FindObjectOfType<GameController>().Win();
        }
    }
}
