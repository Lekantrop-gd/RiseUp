using UnityEngine;

public abstract class EntityView : MonoBehaviour
{
    protected EntityProtector Protector;

    public virtual void Initialize(EntityProtector protector)
    {
        Protector = protector;
    }

    public virtual void SetPosition(Vector2 position)
    {
        transform.position = position;
    }
}
