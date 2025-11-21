using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckCover : MonoBehaviour
{
    // Start is called before the first frame update

    //[SerializeField] private BoxCollider2D bc2d;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
     private void OnTriggerStay2D(Collider2D collision)
   {
      if(collision.gameObject.tag == "Player")
      {
       Debug.Log("INTERACT");
       BrambleMovement B = collision.gameObject.GetComponent<BrambleMovement>();
       B.canBeDamaged = false;
       //bc2d.enabled = false;
      }
       
   }

   private void OnTriggerExit2D(Collider2D collision)
   {
      if(collision.gameObject.tag == "Player")
      {
       Debug.Log("INTERACT");
       BrambleMovement B = collision.gameObject.GetComponent<BrambleMovement>();
       B.canBeDamaged = true;
       //bc2d.enabled = false;
      }
       
   }
}
