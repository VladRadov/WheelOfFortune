using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Wheel : MonoBehaviour
{
    [SerializeField] private Transform _wheel;

    [SerializeField] float _timeRotation;

    [SerializeField] private float _maxSpeed;

    [SerializeField] private List<Sector> _sectors;

    [SerializeField] private WheelView _wheelView;

    private float _currentSpeedRotate;

    private float _minSpeed;

    private bool _activeWheel;

    private const float _percentSpeed = 10.0f;

    private const float _totalPercentSpeed = 100.0f;

    public UnityEvent WheelStopedRotateEventHandler = new UnityEvent();

    private void Start()
    {
        _activeWheel = false;
        _minSpeed = (_maxSpeed * _percentSpeed) / _totalPercentSpeed;
        WheelStopedRotateEventHandler.AddListener(OffWheel);
        WheelStopedRotateEventHandler.AddListener(FindSelectedSector);
    }

    private void FixedUpdate()
    {
        if (_activeWheel)
            Rotate();
    }

    private void Rotate()
    {
        SlowdownCurrentSpeed();
        _wheel.Rotate(new Vector3(0, 0, -_currentSpeedRotate * Time.deltaTime));
    }

    private void SlowdownCurrentSpeed()
    {
        var factorSlowdown = _currentSpeedRotate / 100;
        var tempCurrentSpeed = _currentSpeedRotate - factorSlowdown;
        _currentSpeedRotate = tempCurrentSpeed <= _minSpeed ? _minSpeed : tempCurrentSpeed;
    }

    private IEnumerator StartTimerRotate()
    {
        yield return new WaitForSeconds(_timeRotation);
        WheelStopedRotateEventHandler?.Invoke();
    }

    public void OnWheel()
    {
        if (_activeWheel == false)
        {
            _activeWheel = true;
            _currentSpeedRotate = _maxSpeed;
            StartCoroutine(StartTimerRotate());
        }
    }

    private void OffWheel() => _activeWheel = false;

    private void FindSelectedSector()
    {
        var selectedSector = _sectors.Find(sector => sector.IsSelected);
        StartCoroutine(_wheelView.ViewWinCoins(selectedSector.Coin));
    }
}
