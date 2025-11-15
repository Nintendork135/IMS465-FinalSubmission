using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBeatle : MonoBehaviour
{

    public EnemyPatrol ep;

    public BoxCollider2D bc;
    public BoxCollider2D tc;

    private Animator anim;
    public float squishJump;
    public AudioClip deathSound;
    public AudioSource audioSource;
    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void OnCollisionEnter2D(Collision2D Collision)
    {
        if(Collision.gameObject.CompareTag("Player"))
        {   
            //animation line
            BrambleMovement B = Collision.gameObject.GetComponent<BrambleMovement>();
            anim.SetTrigger("die");
            ep.enabled = false;
            bc.enabled = false;
            tc.enabled = false;
            Collision.gameObject.GetComponent<BrambleMovement>().rb.AddForce(transform.up * squishJump, ForceMode2D.Impulse);
            B.ScoreCount+=100;
            B.UI.UpdateScore();
            audioSource.PlayOneShot(deathSound);
            Destroy(gameObject, anim.GetCurrentAnimatorStateInfo(0).length);
        }
        
    }
}
