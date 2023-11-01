using UnityEngine;

public class ProtectorTransformView : View
{
    private void Update()
    {
        Presenter?.Move(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }
}
