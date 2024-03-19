using UnityEngine;

public class RandomWander : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the spider moves
    public float turnSpeed = 30f; // Speed at which the spider turns to a new direction
    public float directionChangeInterval = 1f; // How often the spider changes its moving direction

    private float nextDirectionChangeTime;

    // Start is called before the first frame update
    void Start()
    {
        nextDirectionChangeTime = Time.time + directionChangeInterval;
    }

    // Update is called once per frame
    void Update()
    {
        // Move the spider forward
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        // Check if it's time to change direction
        if (Time.time >= nextDirectionChangeTime)
        {
            ChangeDirection();
            nextDirectionChangeTime = Time.time + directionChangeInterval;
        }
    }

    void ChangeDirection()
    {
        // Generate a random new rotation for the spider
        float newRotation = Random.Range(-180, 180);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, newRotation, transform.eulerAngles.z);
    }
}