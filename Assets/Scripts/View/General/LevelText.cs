using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelText : UIElement
{
    [SerializeField] private Text _text;
    private int _levelNumber;
    private int _currentLevel;
    private BalloonView _balloon;

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Initialize(int levelNumber, BalloonView balloon)
    {
        _levelNumber = levelNumber;
        _text.text = _currentLevel + "/" + _levelNumber.ToString();
        _balloon = balloon;
    }

    public void AddLevel()
    {
        ++_currentLevel;
        _text.text = _currentLevel + "/" + _levelNumber.ToString();
        if ( _currentLevel == _levelNumber ) 
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnEnable()
    {
        _balloon.OnLevelPassed += AddLevel;
    }

    private void OnDisable()
    {
        _balloon.OnLevelPassed -= AddLevel;
    }
}