using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //[SerializeField]private float FollowSpeed = 2f;
    [SerializeField]private Transform target;
    [SerializeField]private Vector3 offset;
    [Range(1,10)]
    [SerializeField]private float smoothFactor;
    [SerializeField]private Vector3 minValues, maxValues;
    [SerializeField] private bool FoundTarget;


    private void Update()
    {
        if (!FoundTarget && GameObject.FindGameObjectsWithTag("Player").Length > 0)
        {
            target = GameObject.FindWithTag("Player").transform;
            FoundTarget = true;
        }

        if (FoundTarget && GameObject.FindGameObjectsWithTag("Player").Length == 0)
        {
            FoundTarget = false;
        }
    }

    private void FixedUpdate()
    {
        Follow();
    
        //Vector3 newPos = new Vector3(target.position.x, target.position.y, -5f);
        //transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed*Time.deltaTime);
    }

    void Follow()
    {
        if(FoundTarget)
        {
            //define minimum xyz and maximum xyz values

            Vector3 targetPosition = target.position + offset;
            //verify is target position is oob or not
            //limit to min and max values
            //camera bounds
            Vector3 boundPosition = new Vector3(
            Mathf.Clamp(targetPosition.x, minValues.x, maxValues.x), 
            Mathf.Clamp(targetPosition.y, minValues.y, maxValues.y),
            Mathf.Clamp(targetPosition.z, minValues.z, maxValues.z));

            Vector3 smoothPosition = Vector3.Lerp(transform.position, boundPosition, smoothFactor*Time.fixedDeltaTime);
            transform.position = smoothPosition;
            }
        
    }
}
