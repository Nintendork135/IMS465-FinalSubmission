using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjectNoFlip : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private Vector3[] positions;

    private int index;

    public bool faceRight = true;

    public Transform creature;

    public GameObject ObjectLeft;
    public GameObject ObjectRight;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, positions[index], Time.deltaTime * speed);

        if (transform.position == positions[index])
        {
            if (index == positions.Length -1)
            {
                index = 0; //has to be left positon to start, otherwise stuff goes backwards
                if (faceRight && creature != null)
                {
                    Direction();
                }

                else if (faceRight && ObjectLeft != null)
                {
                    ObjectDirection();
                }
            }

            else
            {
                index++;
                if (!faceRight && creature != null)
                {
                    Direction();
                }

                else if (!faceRight && ObjectRight != null)
                {
                    ObjectDirection();
                }
            }
        }
    }

    private void Direction()
    {
        faceRight = !faceRight;
        creature.localScale = new Vector3(-1f * creature.localScale.x, creature.localScale.y, 1f);
    }

    private void ObjectDirection()
    {
        faceRight = !faceRight;
        ObjectLeft.SetActive(!ObjectLeft.activeSelf);
        ObjectRight.SetActive(!ObjectRight.activeSelf);
    }

}
