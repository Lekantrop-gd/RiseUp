using UnityEngine;

public class CompositionRoot : MonoBehaviour
{
    [SerializeField] private UIElement[] _uielements;
    [SerializeField] private BalloonView _balloon;
    [SerializeField] private CameraFollowing _camera;
    [SerializeField] private Protector _protector;
    [SerializeField] private Vector2 _playerStartPosition;
    [SerializeField] private float _balloonRisingSpeed;
    [SerializeField] private float _balloonRisingDelta;
    [SerializeField] private float _animationDuration;
    [SerializeField] private float _protectorFollowingSpeed;

    public void Awake()
    {
        _balloon = Instantiate(_balloon, _playerStartPosition, Quaternion.identity);
        BalloonModel balloonModel = new BalloonModel(_balloon, _playerStartPosition);
        BalloonPresenter balloonPresenter = new BalloonPresenter(balloonModel, _balloonRisingSpeed, _balloonRisingDelta);
        _balloon.Initialize(balloonPresenter);
        _camera.Initialize(_balloon.transform, _balloonRisingSpeed);
    }

    public void StartGame()
    {
        foreach (var uielement in _uielements)
        {
            uielement.Hide(_animationDuration);
        }
        _balloon.StartRisingUp();
        _protector = Instantiate(_protector, _playerStartPosition, Quaternion.identity);
        _protector.Initialize(_protectorFollowingSpeed);
    }
}
