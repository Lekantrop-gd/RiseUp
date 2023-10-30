using System;
using System.Collections;
using UnityEngine;

public class BalloonView : MonoBehaviour
{
    public BalloonPresenter _presenter;
    public Action OnColided;

    public void Initialize(BalloonPresenter presenter)
    {
        _presenter = presenter;
    }

    public void SetPosition(Vector2 position)
    {
        transform.position = position;
    }

    private IEnumerator StartMoving()
    {
        while (true)
        {
            _presenter?.Move();
            yield return null;
        }
    }

    public void StartRisingUp()
    {
        StartCoroutine(StartMoving());
    }

    public void StopRisingUp()
    {
        StopCoroutine(StartMoving());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Obstacle obstacle))
        {
            OnColided?.Invoke();
        }
    }
}