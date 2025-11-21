using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    //DetectionPoint
    private Transform detectionPoint;
    //DetectionRadius
   // private const detectionRadius=0.2f;
    //DetectionLayer
    [SerializeField]private LayerMask detectionLayer;
    public AudioClip keySound;
    public AudioSource audioSource;

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
       B.hasKey = true;
       B.ScoreCount+=200;
       Destroy(gameObject);
       AudioSource.PlayClipAtPoint(keySound, Camera.main.transform.position);
      }
       
   }
}
