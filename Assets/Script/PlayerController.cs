using UnityEngine;
public class PlayerController : MonoBehaviour
{
    // This variable appears in the Inspector.
    // We can change the speed without editing the code.
    public float speed = 10f;
    // rb will store a reference to our Rigidbody component.
    private Rigidbody rb;
    void Start()
 {
 // Get the Rigidbody attached to this same GameObject.
 rb = GetComponent<Rigidbody>();
 }
 void FixedUpdate()
 {
        // Read keyboard input this frame.
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        // Build a movement direction and apply force.
        Vector3 movement = new Vector3(moveX, 0f, moveZ);
        rb.AddForce(movement * speed);
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, 5f, 0), ForceMode.Impulse);
        }

    }

   

}
