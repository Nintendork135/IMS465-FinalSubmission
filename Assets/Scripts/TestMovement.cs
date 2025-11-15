// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class TestMovement : MonoBehaviour
// {
//     //[SerializeField]
//     private float speed = 5f;
//     private Rigidbody2D body;
//     private Animator anim;
//     private bool grounded;

//     private void Awake()
//     {
//         //grab references for rigidbody and animator from object
//         body = GetComponent<Rigidbody2D>();
//         anim = GetComponent<Animator>();
//     }

//     private void Update()
//     {
//         //movement left and right
//         float horizontalInput = Input.GetAxisRaw("Horizontal");
//         body.velocity = new Vector3(Input.GetAxisRaw("Horizontal") * speed, body.velocity.y);

//         //flip player when moving horizontally
//         if(horizontalInput > 0.00f)
//             {
//                 transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
//                 body.constraints = RigidbodyConstraints2D.None;
//                 body.constraints = RigidbodyConstraints2D.FreezeRotation;
//             }
//         else if(horizontalInput < 0.00f)
//             {
//                 transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
//                 body.constraints = RigidbodyConstraints2D.None;
//                 body.constraints = RigidbodyConstraints2D.FreezeRotation;
//             }
//        else if (grounded)
//        {
//             body.constraints = RigidbodyConstraints2D.FreezeAll;
//             body.constraints = RigidbodyConstraints2D.FreezePositionX;
//             body.constraints = RigidbodyConstraints2D.FreezeRotation;
//        }


//         //else if(horizontalInput == 0f && grounded)
//             //body.velocity = new Vector3(0,0,0);
            

//         //player jump anim
//         if(Input.GetKeyDown(KeyCode.Space) && grounded)
//             Jump();

//         //Set animator perameter
//         anim.SetBool("run", horizontalInput != 0);
//        anim.SetBool("grounded", grounded);
//     }

//     private void Jump()
//    {
//        //player jump
//        body.velocity = new Vector2(body.velocity.x, speed + 9f); //
//        //player jump anim
//        anim.SetTrigger("jump");
//        //state that triggers jump anim
//        grounded = false;
//    }

//     //interaction/collision with other tag types
//     private void OnCollisionEnter2D(Collision2D collision)
//    {
//       if(collision.gameObject.tag == "Ground")
//        grounded = true;
//       if(collision.gameObject.tag == "Enemy")
//        grounded = true;
//    }

//     private void OnCollisionExit2D(Collision2D collision)
//    {
//       if(collision.gameObject.tag == "Ground")
//        grounded = false;
//    }

//     void FixedUpdate() 
//     {

//         body.velocity *= 1.000f;

//     }


//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     //void Update()
//     //{
        
//     //}
// }
