using UnityEngine;

public class UIElement : MonoBehaviour
{
    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }
}