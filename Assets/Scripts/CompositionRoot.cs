using UnityEngine;

public class CompositionRoot : MonoBehaviour
{
    [SerializeField] private UIElement[] _uielements;
    [SerializeField] private BalloonView _balloon;
    [SerializeField] private View _protector;
    [SerializeField] private CameraFollowing _camera;
    [SerializeField] private Vector2 _playerStartPosition;
    [SerializeField] private float _balloonRisingSpeed;
    [SerializeField] private float _balloonRisingDelta;
    [SerializeField] private float _animationDuration;
    [SerializeField] private float _protectorFollowingSpeed;
    [SerializeField] private float _cameraFollowingSpeed;

    public void Awake()
    {
        _balloon = Instantiate(_balloon, _playerStartPosition, Quaternion.identity);
        Model balloonModel = new BalloonModel(_balloon, _playerStartPosition);
        Presenter balloonPresenter = new BalloonPresenter(balloonModel, _balloonRisingSpeed, _balloonRisingDelta);
        _balloon.Initialize(balloonPresenter);
    }

    public void StartGame()
    {
        foreach (var uielement in _uielements)
        {
            uielement.Hide(_animationDuration);
        }
        _balloon.StartRisingUp();

        _protector = Instantiate(_protector, _playerStartPosition + Vector2.up, Quaternion.identity);
        Model protectorModel = new ProtectorModel(_protector, _protector.transform.position);
        Presenter protectorPresenter = new ProtectorPresenter(protectorModel, _balloon.transform, _protectorFollowingSpeed);
        _protector.Initialize(protectorPresenter);

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
