using System;
using System.Collections;
using UnityEngine;

public class BalloonView : View
{
    public Action OnColided;
    public Action OnLevelPassed;

    private IEnumerator StartMoving()
    {
        while (true)
        {
            Presenter?.Move();
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
        else if (collision.gameObject.TryGetComponent(out LevelPass levelPass))
        {
            OnLevelPassed?.Invoke();
        }
    }
}