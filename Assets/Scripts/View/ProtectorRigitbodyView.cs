using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ProtectorRigitbodyView : View
{
    private Rigidbody2D _rigitbody;

    private void Awake()
    {
        _rigitbody = GetComponent<Rigidbody2D>();
    }

    public override void SetPosition(Vector2 position)
    {
        _rigitbody?.MovePosition(position);
    }

    private void Update()
    {
        Presenter?.Move(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }
}