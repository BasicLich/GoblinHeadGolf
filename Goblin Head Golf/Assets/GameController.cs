using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{ 
    public GameObject player;
    public GameObject head;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && FindObjectOfType<Player>().GetComponent<Player>().swingFinished)
        {
            var pos = FindObjectOfType<Player>().transform.position;
            Destroy(FindObjectOfType<Player>().gameObject);
            var playerObj = Instantiate(player, pos, Quaternion.identity);
            Instantiate(head, playerObj.GetComponent<Player>().headSpawn, Quaternion.Euler(0f, 0f, 270f));
        }
    }
}
