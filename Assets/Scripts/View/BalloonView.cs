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
}