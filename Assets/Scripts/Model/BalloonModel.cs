using UnityEngine;

public class BalloonModel
{
    private Vector2 _position;
    private BalloonView _balloonView;

    public BalloonModel(BalloonView balloonView)
    {
        _balloonView = balloonView;
    }

    public void SetPosition(Vector2 position)
    {
        _position = position;
        _balloonView.SetPosition(_position);
    }

    public Vector2 GetPosition()
    {
        return _position;
    }
}