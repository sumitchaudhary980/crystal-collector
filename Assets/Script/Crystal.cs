using UnityEngine;
public class Crystal : MonoBehaviour
{
    // How fast the crystal spins (degrees per second).
    public float spinSpeed = 90f;
    void Update()
    {
        // Rotate around the Y axis every frame.
        // Time.deltaTime ensures the speed is frame-rate independent.
        transform.Rotate(0, spinSpeed * Time.deltaTime, 0);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Tell the GameManager a crystal was collected.
            GameManager.instance.CrystalCollected();
            // Then destroy this crystal.
            Destroy(gameObject);
        }
    }
}