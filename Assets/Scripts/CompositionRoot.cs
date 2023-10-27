using UnityEngine;

public class CompositionRoot : MonoBehaviour
{
    [SerializeField] private BalloonView _balloon;
    [SerializeField] private CameraFollowing _camera;
    [SerializeField] private Vector2 _playerStartPosition;
    [SerializeField] private float _balloonRisingSpeed;
    [SerializeField] private float _balloonRisingDelta;

    private BalloonPresenter _balloonPresenter;

    public void Awake()
    {
        BalloonView balloon = Instantiate(_balloon, _playerStartPosition, Quaternion.identity);
        BalloonModel balloonModel = new BalloonModel(balloon);
        _balloonPresenter = new BalloonPresenter(balloonModel, _balloonRisingSpeed, _balloonRisingDelta);
        balloon.Initialize(_balloonPresenter);
        _camera.Initialize(_balloon.transform, _balloonRisingSpeed);
    }

    public void StartGame()
    {
        StartCoroutine(_balloonPresenter.StartRisingUp());
        StartCoroutine(_camera.StartFolowing());
    }
}
