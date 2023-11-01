using UnityEngine;

public abstract class Presenter
{
    protected Model Model;

    public Presenter(Model model)
    {
        Model = model;
    }

    public abstract void Move();
}
