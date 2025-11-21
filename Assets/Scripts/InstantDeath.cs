using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantDamage : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private BoxCollider2D bc2d;
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
        Debug.Log("INTERACT");
       BrambleMovement B = collision.gameObject.GetComponent<BrambleMovement>();
       B.Damage(3);
       bc2d.enabled = false;
       StartCoroutine(RedoBoxCollider()); 
      }
       
   }

   private IEnumerator RedoBoxCollider()
   {
    yield return new WaitForSeconds(2f);
    bc2d.enabled = true;
   }
}
