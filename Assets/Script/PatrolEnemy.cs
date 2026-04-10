using UnityEngine;
public class PatrolEnemy : MonoBehaviour
{
    public Transform waypointA; // drag WaypointA here in Inspector
    public Transform waypointB; // drag WaypointB here in Inspector
    public float speed = 4f;
    private Transform currentTarget;
        public static GameManager instance;

    void Start()
    {
        currentTarget = waypointA;
    }
    void Update()
    {
        // Move towards the current target waypoint.
        transform.position = Vector3.MoveTowards(
        transform.position,
        currentTarget.position,
        speed * Time.deltaTime
        );
        // If we reached the target, switch to the other one.
        if (Vector3.Distance(transform.position, currentTarget.position) < 0.1f)
        {
            currentTarget = (currentTarget == waypointA) ? waypointB : waypointA;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        // If the player hits us, trigger game over.
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.TriggerGameOver();
        }
    }
}
