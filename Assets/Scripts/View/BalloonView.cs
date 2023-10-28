using System.Collections;
using UnityEngine;

public class BalloonView : MonoBehaviour
{
    private BalloonPresenter _presenter;

    public void Initialize(BalloonPresenter balloonPresenter)
    {
        _presenter = balloonPresenter;
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
        StopRisingUp();
    }
}