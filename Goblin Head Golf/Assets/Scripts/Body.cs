using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    public ParticleSystem ps;
  
    public void EnablePS()
    {
        ps.Play();
    }
}
