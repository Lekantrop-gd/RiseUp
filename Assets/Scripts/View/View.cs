using UnityEngine;

public abstract class View : MonoBehaviour
{
    protected Presenter Presenter;

    public virtual void Initialize(Presenter presenter)
    {
        Presenter = presenter;
    }

    public virtual void SetPosition(Vector2 position)
    {
        transform.position = position;
    }
}
