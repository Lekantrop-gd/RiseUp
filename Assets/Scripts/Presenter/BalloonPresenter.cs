using System.Collections;
using UnityEngine;

public class BalloonPresenter
{
    private BalloonModel _model;
    private float _risingSpeed;
    private float _risingDelta;

    public BalloonPresenter(BalloonModel model, float risingSpeed, float risingDelta)
    {
        _model = model;
        _risingSpeed = risingSpeed;
        _risingDelta = risingDelta;
    }

    public IEnumerator StartRisingUp()
    {
        while (true)
        {
            Vector2 position = Vector2.MoveTowards(
                _model.GetPosition(), 
                new Vector2(_model.GetPosition().x, _model.GetPosition().y + _risingDelta), 
                Time.deltaTime * _risingSpeed
            );
            _model.SetPosition(position);
            yield return new WaitForEndOfFrame();
        }
    }
}