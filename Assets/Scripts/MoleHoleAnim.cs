using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleHoleAnim : MonoBehaviour

{

   // public Animator anim; 


    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
