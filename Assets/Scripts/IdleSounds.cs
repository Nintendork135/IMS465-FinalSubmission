using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleSounds : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip idleSound;
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
            Debug.Log("NOISE");
            BrambleMovement B = collision.gameObject.GetComponent<BrambleMovement>();
            AudioSource.PlayClipAtPoint(idleSound, Camera.main.transform.position);
        }
    }
}
