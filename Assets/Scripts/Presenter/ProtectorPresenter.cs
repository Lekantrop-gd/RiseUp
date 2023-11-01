using UnityEngine;

public class ProtectorPresenter : Presenter
{
    private Transform _balloon;
    private float _followingSpeed;

    public ProtectorPresenter(Model model, Transform balloon, float followingSpeed) : base(model)
    {
        _balloon = balloon;
        _followingSpeed = followingSpeed;
    }

    public override void Move(Vector3 target)
    {
        Vector2 position = Vector2.MoveTowards(
            Model.GetPosition(),
            target,
            _followingSpeed * Time.deltaTime);
        
        Model.SetPosition(position);
    }
}