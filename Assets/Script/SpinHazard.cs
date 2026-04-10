using UnityEngine;
public class SpinHazard : MonoBehaviour
{
    public float spinSpeed = 120f;
    void Update()
    {
        transform.Rotate(0, spinSpeed * Time.deltaTime, 0);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.TriggerGameOver();
        }
    }
}