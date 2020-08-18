using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{

    public float clubForce;
    public Vector2 clubAngle;

    private bool hasHit = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "head" && !hasHit)
        {
            collision.gameObject.GetComponent<Head>().EnableRenderer();
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(clubAngle.normalized * clubForce * FindObjectOfType<Player>().power);
            hasHit = true;
        }
    }
}
