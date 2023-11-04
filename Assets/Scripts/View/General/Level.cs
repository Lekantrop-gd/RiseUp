using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private Transform _background;

    public float GetHeight()
    {
        return _background.localScale.y;
    }
}
