using UnityEngine;

public abstract class Model
{
    protected View View;
    protected Vector3 Position;

    public Model(View view, Vector3 position)
    {
        View = view;
        Position = position;
    }

    public virtual void SetPosition(Vector3 position)
    {
        Position = position;
        View.SetPosition(position);
    }

    public virtual Vector3 GetPosition()
    {
        return Position;
    }
}