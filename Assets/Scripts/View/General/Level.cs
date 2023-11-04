using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private Collider2D _background;

    public float GetHeight()
    {
        return _background.bounds.size.y;
    }
}
