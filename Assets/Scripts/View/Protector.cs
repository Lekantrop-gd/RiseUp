using UnityEngine;

public class Protector : MonoBehaviour
{
    private float _followingSpeed;

    public void Initialize(float followingSpeed)
    {
        _followingSpeed = followingSpeed;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            Camera.main.ScreenToWorldPoint(Input.mousePosition),
            _followingSpeed * Time.deltaTime);
    }
}
