using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablePickup : MonoBehaviour
{
    //DetectionPoint
    //DetectionRadius
   // private const detectionRadius=0.2f;
    //DetectionLayer
    public bool isHeart;
    public bool isCoin;
    public AudioClip coinSound;
    public AudioClip heartSound;
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
       if (isHeart)
       {
        B.ScoreCount+=50;
        AudioSource.PlayClipAtPoint(heartSound, Camera.main.transform.position);
        if (B.lives < 3)
       {
        B.lives ++;
        B.UI.UpdateLives(B.lives);
       }
       }
       
       if (isCoin)
       {
            B.ScoreCount+=10;
            AudioSource.PlayClipAtPoint(coinSound, Camera.main.transform.position);
       }

          

        B.UI.UpdateScore();
       
       Destroy(gameObject);
      }
       
   }
}
