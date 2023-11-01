using UnityEngine;

public abstract class EntityProtector
{
    protected EntityModel Model;

    public EntityProtector(EntityModel model)
    {
        Model = model;
    }

    public abstract void Move(Vector3 position);
}
