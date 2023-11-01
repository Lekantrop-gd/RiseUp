using UnityEngine;

public class CompositionRoot : MonoBehaviour
{
    [SerializeField] private UIElement[] _uielements;
    [SerializeField] private BalloonView _balloon;
    [SerializeField] private CameraFollowing _camera;
    [SerializeField] private ProtectorView _protector;
    [SerializeField] private Vector2 _playerStartPosition;
    [SerializeField] private float _balloonRisingSpeed;
    [SerializeField] private float _balloonRisingDelta;
    [SerializeField] private float _animationDuration;
    [SerializeField] private float _protectorFollowingSpeed;
    [SerializeField] private float _cameraFollowingSpeed;

    public void Awake()
    {
        _balloon = Instantiate(_balloon, _playerStartPosition, Quaternion.identity);
        BalloonModel balloonModel = new BalloonModel(_balloon, _playerStartPosition);
        BalloonPresenter balloonPresenter = new BalloonPresenter(balloonModel, _balloonRisingSpeed, _balloonRisingDelta);
        _balloon.Initialize(balloonPresenter);
    }

    public void StartGame()
    {
        foreach (var uielement in _uielements)
        {
            uielement.Hide(_animationDuration);
        }
        _balloon.StartRisingUp();
        _camera.Initialize(_balloon.transform, _cameraFollowingSpeed);
    }

    private void GameOver()
    {
        //Currently empty
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
