using UnityEngine;
using UnityEngine.SceneManagement;

public class CompositionRoot : MonoBehaviour
{
    [SerializeField] private UIElement[] _uielements;
    [SerializeField] private Score _score;
    [SerializeField] private LevelText _level;
    [SerializeField] private LevelGenerator _levelGenerator;
    [SerializeField] private BalloonView _balloon;
    [SerializeField] private CameraFollowing _camera;
    [SerializeField] private View _protectorRigitbody;
    [SerializeField] private View _protectorTransform;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private bool _isProtectorTransform;
    [SerializeField] private Vector2 _playerStartPosition;
    [SerializeField] private float _balloonRisingSpeed;
    [SerializeField] private float _balloonRisingDelta;
    [SerializeField] private float _animationDuration;
    [SerializeField] private float _protectorFollowingSpeed;
    [SerializeField] private float _cameraFollowingSpeed;
    [SerializeField] private float _timeScale;

    private View _protector;

    public void Awake()
    {
        _balloon = Instantiate(_balloon, _playerStartPosition, Quaternion.identity);
        Model balloonModel = new BalloonModel(_balloon, _playerStartPosition);
        Presenter balloonPresenter = new BalloonPresenter(balloonModel, _balloonRisingSpeed, _balloonRisingDelta, _score);
        _balloon.Initialize(balloonPresenter);

        _level.Initialize(_levelGenerator.LevelCount, _balloon);
        Time.timeScale = _timeScale;
    }

    public void StartGame()
    {
        foreach (var uielement in _uielements)
        {
            uielement.Hide(_animationDuration);
        }
        _balloon.StartRisingUp();

        _protector = Instantiate(_isProtectorTransform ? _protectorTransform : _protectorRigitbody, _playerStartPosition + Vector2.up, Quaternion.identity);
        Model protectorModel = new ProtectorModel(_protector, _protector.transform.position);
        Presenter protectorPresenter = new ProtectorPresenter(protectorModel, _protectorFollowingSpeed);
        _protector.Initialize(protectorPresenter);

        _camera.Initialize(_balloon.transform, _cameraFollowingSpeed);
        _levelGenerator.Inialize();
        _score.Show();
        _level.Show();
    }

    private void GameOver()
    {
        _gameOverPanel.SetActive(true);
        Destroy(_balloon.gameObject);
        Destroy(_protector.gameObject);
        Destroy(_camera);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

    private void OnEnable()
    {
        _balloon.OnColided += GameOver;
    }

    private void OnDisable()
    {
        _balloon.OnColided -= GameOver;
    }
}
