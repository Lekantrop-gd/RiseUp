using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Level _entryLevel;
    [SerializeField] private Level[] _levels;
    [SerializeField] private int _levelCount;
    public int LevelCount {  get { return _levelCount; } }

    public void Inialize()
    {
        Level previousLevel = Instantiate(_entryLevel, Vector2.zero, Quaternion.identity);
        previousLevel.transform.parent = transform;

        for (int x = 1; x < _levelCount; x++)
        {
            Level level = _levels[Random.Range(0, _levels.Length)];
            level = Instantiate(level, 
                new Vector2(0, previousLevel.transform.position.y + previousLevel.GetHeight() / 2 + level.GetHeight() / 2), 
                Quaternion.identity);
            level.transform.SetParent(transform);
            level.Initialize(x);
            previousLevel = level;
        }
    }
}