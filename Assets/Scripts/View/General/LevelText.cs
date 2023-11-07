using UnityEngine;
using UnityEngine.UI;

public class LevelText : UIElement
{
    [SerializeField] private Text _text;
    private int _levelNumber;
    private int _currentLevel;

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Initialize(int levelNumber)
    {
        _levelNumber = levelNumber;
        _text.text = _currentLevel + "/" + _levelNumber.ToString();
    }

    public void AddLevel()
    {
        _currentLevel++;
        _text.text = _currentLevel + "/" + _levelNumber.ToString(); ;
    }
}