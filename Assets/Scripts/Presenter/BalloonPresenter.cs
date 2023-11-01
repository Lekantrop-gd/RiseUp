using UnityEngine;

public class BalloonPresenter : Presenter
{
    private float _risingSpeed;
    private float _risingDelta;

    public BalloonPresenter(Model model, float risingSpeed, float risingDelta) : base(model)
    {
        _risingSpeed = risingSpeed;
        _risingDelta = risingDelta;
    }

    public override void Move(Vector3 target)
    {
        Vector2 position = Vector2.MoveTowards(
            Model.GetPosition(), 
            new Vector2(Model.GetPosition().x, Model.GetPosition().y + _risingDelta), 
            Time.deltaTime * _risingSpeed
        );
        Model.SetPosition(position);
    }
}