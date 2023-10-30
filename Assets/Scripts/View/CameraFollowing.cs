using System.Collections;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    [SerializeField] private float _offset;
    private float _followingSpeed;
    private Transform _balloon;

    public void Initialize(Transform balloon, float followingSpeed) 
    {  
        _followingSpeed = followingSpeed;
        _balloon = balloon;
        StartCoroutine(StartFollowing());
    }

    private IEnumerator StartFollowing()
    {
        while (true)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                new Vector3(_balloon.position.x, _balloon.position.y + _offset, transform.position.z),
                _followingSpeed * Time.deltaTime
            );
            yield return null;
        }
    }
}