using UnityEngine;

public abstract class EntityModel
{
    protected EntityView View;
    protected Vector3 Position;

    public EntityModel(EntityView view, Vector3 position)
    {
        View = view;
        Position = position;
    }

    public void SetPosition(Vector3 position)
    {
        Position = position;
        View.SetPosition(position);
    }
}