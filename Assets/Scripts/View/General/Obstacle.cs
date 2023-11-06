using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Obstacle : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.isKinematic = true;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _rigidbody.isKinematic = false;
    }
}