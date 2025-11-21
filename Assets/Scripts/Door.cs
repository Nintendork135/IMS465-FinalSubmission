using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

  public Animator anim; 

  public AudioClip doorSound;

  public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
   {
      if(collision.gameObject.tag == "Player")
      {
        Debug.Log("UNLOCK");
        BrambleMovement B = collision.gameObject.GetComponent<BrambleMovement>();
        if (B.hasKey == true)
        {
            B.hasKey = false;
            //animation line
            anim.SetTrigger("HasKey");
            Destroy(gameObject, anim.GetCurrentAnimatorStateInfo(0).length);
            AudioSource.PlayClipAtPoint(doorSound, Camera.main.transform.position);
        }
        
      }
       
   }
}
