using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWarpLoop : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] BoxCollider2D pushBox;
    [SerializeField] BoxCollider2D hurtBox;
    [SerializeField] private float moveDistance;
    [SerializeField] private bool isVertical;
    private Vector3 startPoint;
    private Vector3 endPoint;
    public bool isWaiting = false;
    public float waitTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        startPoint = this.gameObject.transform.position;

        if (isVertical)
        {
            endPoint = new Vector3(startPoint.x, moveDistance + startPoint.y, startPoint.z);
        }

        else
        {
            endPoint = new Vector3(moveDistance + startPoint.x, startPoint.y, startPoint.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isWaiting == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, endPoint, Time.deltaTime * speed);
            //transform.position = Vector2.MoveTowards(transform.position, positions[index], t);

            if (Vector2.Distance(this.gameObject.transform.position, endPoint) < 0.1f)
            {
                this.gameObject.transform.position = startPoint;
                isWaiting = true;
                pushBox.enabled = false;
                hurtBox.enabled = false;
                this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                StartCoroutine(WaitCode());
            }
        }

    }

    private IEnumerator WaitCode()
    {
        yield return new WaitForSeconds(waitTime);
        isWaiting = false;
        pushBox.enabled = true;
        hurtBox.enabled = true;
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }
}

//wait time of zero makes all the looping for stuff like centipedes act normal styles