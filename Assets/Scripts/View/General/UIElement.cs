using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class UIElement : MonoBehaviour
{
    [SerializeField] private bool _isButton;
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public virtual void Hide(float animationDuration)
    {
        if (_isButton)
        {
            Button button;
            if (TryGetComponent(out button))
            {
                button.interactable = false;
            }
        }
        StartCoroutine(Vanish(animationDuration));
    }   

    private IEnumerator Vanish(float animationDuration)
    {
        float time = 0;
        Color imageColor = _image.color;

        while (time < 1)
        {
            _image.color = Color.Lerp(imageColor, new Color(imageColor.r, imageColor.g, imageColor.b, 0), time);
            time += Time.deltaTime / animationDuration;
            yield return null;
        }

        gameObject.SetActive(false);
    }
}