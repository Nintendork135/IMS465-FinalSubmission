using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPickup : MonoBehaviour
{
    //DetectionPoint
    private Transform detectionPoint;
    //DetectionRadius
   // private const detectionRadius=0.2f;
    //DetectionLayer
    [SerializeField]private LayerMask detectionLayer;
    public bool isHeart;
    public bool isCoin;

    // Update is called once per frame
    void Update()
    {
        
    }

    //bool InteractInput()
    //{
     //   input.GetKeyDown(KeyCode.E);
    //}

    private void OnTriggerEnter2D(Collider2D collision)
   {
      if(collision.gameObject.tag == "Player")
      {
        Debug.Log("INTERACT");
       BrambleMovement B = collision.gameObject.GetComponent<BrambleMovement>();
       if (isHeart)
       {
        if (B.lives < 3)
       {
        B.lives ++;
        B.UI.UpdateLives(B.lives);
       }
       }
       
       //if (isCoin)
       
       Destroy(gameObject);
      }
       
   }
}
