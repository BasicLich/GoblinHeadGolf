using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    private float counter = 0f;
    private bool hasHoled = false;

    private bool hasSplashed = false;
    private bool hasTreed = false;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "hard" && Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y) > 0.2f && Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > 0.2f)
        {
            FindObjectOfType<AudioManager>().Play("thud2");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "water" && GetComponent<Rigidbody2D>().velocity.magnitude > 1f && !hasSplashed)
        {
            FindObjectOfType<AudioManager>().Play("splash");
            hasSplashed = true;
        }

        if (collision.gameObject.tag == "tree" && GetComponent<Rigidbody2D>().velocity.magnitude > 1f && !hasTreed)
        {
            FindObjectOfType<AudioManager>().Play("tree");
            hasTreed = true;
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
