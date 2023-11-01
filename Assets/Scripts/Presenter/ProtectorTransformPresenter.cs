using UnityEngine;

public class ProtectorTransformPresenter : Presenter
{
    private Transform _balloon;
    private float _followingSpeed;

    public ProtectorTransformPresenter(Model model, Transform balloon, float followingSpeed) : base(model)
    {
        _balloon = balloon;
        _followingSpeed = followingSpeed;
    }

    public override void Move()
    {
        Vector2 position = Vector2.MoveTowards(
            Model.GetPosition(),
            _balloon.position,
            _followingSpeed * Time.deltaTime);
        
        Model.SetPosition(position);
    }
}