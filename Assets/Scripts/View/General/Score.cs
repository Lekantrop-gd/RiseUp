using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text _score;

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void SetScore(int score)
    {
        _score.text = score.ToString();
    }
}
