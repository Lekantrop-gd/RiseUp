using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] private Transform _background;
    [SerializeField] private Text _levelText;

    public void Initialize(int level)
    {
        _levelText.text = level.ToString();
    }

    public float GetHeight()
    {
        return _background.localScale.y;
    }
}
