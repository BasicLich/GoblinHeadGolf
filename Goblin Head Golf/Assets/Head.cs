using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<TrailRenderer>().enabled = false;
    }

    public void EnableRenderer()
    {
        GetComponent<TrailRenderer>().enabled = true;
    }
}
