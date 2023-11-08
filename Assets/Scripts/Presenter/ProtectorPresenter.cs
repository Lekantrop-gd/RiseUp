using UnityEngine;

public class ProtectorPresenter : Presenter
{
    private float _followingSpeed;

    public ProtectorPresenter(Model model, float followingSpeed) : base(model)
    {
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