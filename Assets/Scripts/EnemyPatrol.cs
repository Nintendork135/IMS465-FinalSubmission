using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private Vector3[] positions;

    private int index;

    private bool faceRight = false;
    //public AudioClip idleSound;
    //public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        //var t = 0.5f;


        transform.position = Vector2.MoveTowards(transform.position, positions[index], Time.deltaTime * speed);
        //transform.position = Vector2.MoveTowards(transform.position, positions[index], t);
       // audioSource.PlayOneShot(idleSound);

        if (transform.position == positions[index])
        {
            if (index == positions.Length -1)
            {
                index = 0; //has to be left positon to start, otherwise stuff goes backwards
                if (faceRight)
                {
                    Direction();
                }
            }

            else
            {
                index++;
                if (!faceRight)
                {
                    Direction();
                }
            }
        }
    }

    private void Direction()
    {
        faceRight = !faceRight;
        transform.Rotate(0f, 180f, 0f);
    }

}
