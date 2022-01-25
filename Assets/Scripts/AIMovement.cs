using UnityEngine;

public class AIMovement : MonoBehaviour
{
    private Transform _currentTarget;
    private GameObject[] _targets;
    [SerializeReference] string targetTag;
    [SerializeField]float movementSpeed = 10f;
    [SerializeField] float rotationalDamp = 0.5f;

    [SerializeField] float detectionDistance = 20f;
    [SerializeField] float rayCastYOffset = 2.5f;
    [SerializeField] float rayCastXOffset = 2.5f;
    [SerializeField] float startPoint = 5f;


    void Update()
    {
        TargetSwitching();
        Move();
        Pathfinding();
    }
    void Turn()
    {
        if (_currentTarget != null)
        {
            Vector3 newPos = _currentTarget.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(newPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationalDamp * Time.deltaTime);
        }
    }
    void Move()
    {
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
    }

    void Pathfinding()
    {
        //checks what is ahead of AI, depending on where this objects blocks the view of the ai it will try to turn away
        RaycastHit hit;
        Vector3 raycastOffset=Vector3.zero;
        /*these are the points i am raycasting from to check where
        collisions are happening                                */
        Vector3 left = transform.position - transform.right*rayCastXOffset-transform.forward*startPoint;
        Vector3 right = transform.position + transform.right * rayCastXOffset - transform.forward * startPoint;
        Vector3 up = transform.position + transform.up * rayCastYOffset - transform.forward * startPoint;
        Vector3 down = transform.position - transform.up * rayCastYOffset - transform.forward * startPoint;

       // Debug.DrawRay(left, transform.forward*detectionDistance, Color.yellow);
       // Debug.DrawRay(right, transform.forward * detectionDistance, Color.yellow);
       // Debug.DrawRay(up, transform.forward * detectionDistance, Color.yellow);
       // Debug.DrawRay(down, transform.forward * detectionDistance, Color.yellow);

        if (Physics.Raycast(left,transform.forward,out hit, detectionDistance))
        {
            raycastOffset += Vector3.up;
        }
        else if (Physics.Raycast(right, transform.forward, out hit, detectionDistance))
        {
            raycastOffset += Vector3.down;
        }

        if (Physics.Raycast(up, transform.forward, out hit, detectionDistance))
        {
            raycastOffset += Vector3.left;
        }
        else if (Physics.Raycast(down, transform.forward, out hit, detectionDistance))
        {
            raycastOffset -= Vector3.right;
        }

        if (raycastOffset != Vector3.zero)
        {
            transform.Rotate(raycastOffset * 50f * Time.deltaTime);
        }
        else
        {
            Turn();
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ally") || other.gameObject.CompareTag("Enemy"))
        {
            Explosions temp = transform.root.GetComponent<Explosions>();
            if (temp != null)
                temp.CollidedWithEnemy();
        }
    }
    public Transform GetTarget()
    {
        return _currentTarget;
    }
    private void TargetSwitching()
    {
        _targets = GameObject.FindGameObjectsWithTag(targetTag);
        GameObject closest = _targets[0];
        _currentTarget = closest.transform ;
        foreach (GameObject target in _targets)
        {
            if (Vector3.Distance(transform.position, target.transform.position) < Vector3.Distance(transform.position, closest.transform.position))
            {
                closest = target;
                _currentTarget = target.transform;
            }
        }
    }


}
