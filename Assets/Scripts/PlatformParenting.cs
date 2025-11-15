using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformParenting : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform Player;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("EGG");
            Player = GameObject.Find("Player(Clone)").GetComponent<Transform>();
            Player.parent = transform.parent;
        }
        //else
        //{
        //    Debug.Log("EGG");
         //   Player = GameObject.Find("PlayerTwo(Clone)").GetComponent<Transform>();
         //   Player.parent = transform.parent;
      //  }
    }

    void OnCollisionExit2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.parent = null;
        }
    }
}
