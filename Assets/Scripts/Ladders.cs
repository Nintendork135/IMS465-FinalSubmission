using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladders : MonoBehaviour
{
    [SerializeField] private BoxCollider2D bc2d;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                Debug.Log("LADDER");
                BrambleMovement B = collision.gameObject.GetComponent<BrambleMovement>();
                B.ladderPos = this.gameObject.transform;
                B.turnOnLadder(true);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("LADDER");
                BrambleMovement B = collision.gameObject.GetComponent<BrambleMovement>();
                B.ladderPos = this.gameObject.transform;
                B.turnOnLadder(true);
            }
            
        }

    }
   
   private void OnTriggerExit2D(Collider2D collision)
   {
      if(collision.gameObject.tag == "Player")
      {
        Debug.Log("LADDER");
       BrambleMovement B = collision.gameObject.GetComponent<BrambleMovement>();
       B.turnOnLadder(false);
      }
       
   }
}

//for ladders, use variable to freeze X position and have the Y position increase/decrease by a bit every frame