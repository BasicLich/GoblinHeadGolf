using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float swingAddAmount = 1f;
    private float speedMultiplier = 5f;

    public Transform club;
    public Transform swingPoint;
    public Transform spriteTrans;
    public GameObject headSpawnObj;
    public Vector3 headSpawn;

    private bool hasReleased = false;
    private bool spaceDown = false;
    public bool swingFinished = false;
    private bool maxCharge = false;
    private float currentChargeAngle = 225f;

    public float power = 0f;

    private void Awake()
    {
        headSpawn = headSpawnObj.transform.position;
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            spaceDown = true;
            hasReleased = false;
            currentChargeAngle = club.eulerAngles.z;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            hasReleased = true;
            spaceDown = false;
            maxCharge = false;
        }

        if (hasReleased && club.eulerAngles.z > 260 + (90 * (80 / currentChargeAngle)))
        {
            swingFinished = true;
        }

        if(!hasReleased && club.eulerAngles.z < 80)
        {
            maxCharge = true;
        }

        power = Mathf.Pow(225f / currentChargeAngle, 2);
        Debug.Log(power);

    }

    private void FixedUpdate()
    {
        if(spaceDown && !hasReleased && !maxCharge && !swingFinished)
        {
            club.RotateAround(swingPoint.position, Vector3.forward, -swingAddAmount * Time.deltaTime);
            speedMultiplier += 5f * Time.deltaTime;
        }

        if (hasReleased && !swingFinished)
        {
            club.RotateAround(swingPoint.position, Vector3.forward, swingAddAmount * speedMultiplier * Time.deltaTime);
        }

        Debug.Log(club.eulerAngles.ToString());

    }
}
