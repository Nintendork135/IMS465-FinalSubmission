using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BrambleMovement : MonoBehaviour
{
    //[SerializeField]
    private float Move;
    public float speed;
    public Rigidbody2D rb;
    private Animator anim;
    private bool grounded;
    [SerializeField] private bool isOnLadder;
    public Transform ladderPos;
    public Vector2 boxSize;
    public float castDistance;
    public float jump;
    public LayerMask groundLayer;
    public int lives = 3;
    public BoxCollider2D bc;
    private PhysicsMaterial2D friction;
    public PhysicsMaterial2D newFriction;
    private RaycastHit slopeHit;
    public float maxSlopeAngle;
    public float playerHeight;
    private Vector2 direction;

    public bool hasKey;
    public bool canBeDamaged;
    public UIManager UI;
    private GameManager GM;
    public int ScoreCount;
    public AudioClip jumpSound;
    public AudioClip hurtSound;
    public AudioClip deathSound;
    public AudioSource audioSource;
    //ublic AudioClip deathSound; do as many as necessary for character sounds

    private void Awake()
    {
        //grab references for rigidbody and animator from object
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        bc = GetComponent<BoxCollider2D>();

        UI = GameObject.Find("UIManager").GetComponent<UIManager>();
        if (UI != null)
            UI.UpdateLives(lives);
    }

    private void Update()
    {
        Move = Input.GetAxisRaw("Horizontal");



        // if (isGrounded() && Move == 0) //&& grounded
        // {
        //     rb.velocity = new Vector2(0, 0);
        //     bc.sharedMaterial = newFriction;
        //     rb.sharedMaterial = newFriction;
        //     Debug.Log(Move);

        // }
        if (Move != 0) //&& grounded
        {

            rb.velocity = new Vector2(Move * speed, rb.velocity.y);
            Debug.Log(Move);

        }

        //flip sprite when moving
        if (Move > 0.00f)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        else if (Move < 0.00f)
        {
            transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        //player jump anim
        if (Input.GetButtonDown("Jump") && isGrounded())
            Jump();

        //Set animator perameter
        anim.SetBool("run", Move != 0);
        anim.SetBool("grounded", isGrounded());
        anim.SetBool("climb", isOnLadder);
        if (OnSlope())
        {
            rb.gravityScale = 0;
            rb.velocity = new Vector2(speed * 2f, rb.velocity.y);
        }
        else
        {
            rb.gravityScale = 3;
        }

        if (isOnLadder)
        {
            this.gameObject.transform.position = new Vector3(ladderPos.position.x,
                this.gameObject.transform.position.y, this.gameObject.transform.position.z);
                

            rb.gravityScale = 0.0f;
            Move = Input.GetAxisRaw("Vertical");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("NO LADDER");
                isOnLadder = false;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("NO LADDER");
                isOnLadder = false;
                //rb.velocity = new Vector2(rb.velocity.x, speed * 2f);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                Debug.Log("NO LADDER");
                isOnLadder = false;
                //rb.velocity = new Vector2(rb.velocity.x, speed * 2f);
            }
            if (Input.GetKey(KeyCode.W))
            {
                rb.velocity = new Vector2(rb.velocity.y/5, speed * 1.0f);
                anim.SetTrigger("climb");
            }
            if (Input.GetKey(KeyCode.S))
            {
                rb.velocity = new Vector2(rb.velocity.y/5, speed * -1.0f);
                anim.SetTrigger("climb");
            }

        }
    } 

    private void FixedUpdate()
    {
        isGrounded();
        OnSlope();
    }
    private void Jump()
    {
        //player jump
        rb.velocity = (new Vector2(rb.velocity.x, 0f));
        rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        //    body.velocity = new Vector2(body.velocity.x, speed + 9f); //
        //player jump anim
        anim.SetTrigger("jump");
        audioSource.PlayOneShot(jumpSound);
        //state that triggers jump anim
        isOnLadder = false;
    }

    private bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f + 0.4f))
        {
            float angle = Vector2.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle != 30;
        }
        return false;
    }

    public Vector2 GetSlopeDirection(Vector2 D)
    {
        return Vector3.ProjectOnPlane(D, slopeHit.normal).normalized;
    }
    public bool isGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
        {

            return true;

        }
        else
        {
            return false;

        }
    } 


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSize);
    }

    public void Damage(int damageValue)
    {
        if (canBeDamaged)
        {
            lives -= damageValue;
            if (lives >= 1)
            {
                anim.SetTrigger("hurt");
                audioSource.PlayOneShot(hurtSound);
            }

            if (UI != null && lives >= 0)
                UI.UpdateLives(lives); //actual parameter
        }
        canBeDamaged = false;
        StartCoroutine(EnableDamage());

        if (lives <= 0)
        {
            UI.UpdateLives(0); //actual parameter

            if (GM != null)
                GM.gameOver = true;

            //turn it on

            anim.SetTrigger("die");
            audioSource.PlayOneShot(deathSound);

            if (UI != null)
                StartCoroutine("EndGame");
        }
    }

    private IEnumerator EnableDamage()
    {
        yield return new WaitForSeconds(2f);
        canBeDamaged = true;
    }

    private IEnumerator EndGame()
    {
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        SceneManager.LoadScene("LevelSelect");
    }

    public void turnOnLadder(bool val)
    {
        isOnLadder = val;
    }


}


//for ladders, use variable to freeze X position and have the Y position increase/decrease by a bit every frame