using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{

    public float clubForce;
    public Vector2 clubAngle;
    public Sprite[] sprites;

    public Color normal;

    private bool hasHit = false;

    private void Awake()
    {
        SetClubType();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "head" && !hasHit)
        {
            collision.gameObject.GetComponent<Head>().EnableRenderer();
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(clubAngle.normalized * clubForce * FindObjectOfType<Player>().power);
            hasHit = true;
            FindObjectOfType<Body>().EnablePS();
        }
    }

    public void SetClubType()
    {
        switch (FindObjectOfType<GameController>().currentClub)
        {
            case 0:
                clubAngle = new Vector2(0.5f, 0.5f);
                clubForce = 2f;
                GetComponent<SpriteRenderer>().sprite = sprites[0];
                GetComponent<SpriteRenderer>().color = normal;
                break;
            case 1:
                clubAngle = new Vector2(0.3f, 0.7f);
                clubForce = 2f;
                GetComponent<SpriteRenderer>().sprite = sprites[1];
                GetComponent<SpriteRenderer>().color = normal;
                break;
            case 2:
                clubAngle = new Vector2(0.7f, 0.3f);
                clubForce = 2f;
                GetComponent<SpriteRenderer>().sprite = sprites[2];
                GetComponent<SpriteRenderer>().color = normal;
                break;
            default:
                clubAngle = new Vector2(0.5f, 0.5f);
                clubForce = 2f;
                GetComponent<SpriteRenderer>().sprite = sprites[0];
                GetComponent<SpriteRenderer>().color = normal;
                break;
        }
    }
}
