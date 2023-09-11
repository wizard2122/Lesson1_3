using System;
using UnityEngine;

public class Sherif : MonoBehaviour, IMovable
{
    private IMover _mover;

    private bool _isInit;

    public void Initialize(IMover mover)
    {
        SetMover(mover);
        _isInit = true;
    }

    [field: SerializeField] public float Speed { get; private set; }

    public Transform Transform => transform;

    private void Update()
    {
        if (_isInit == false)
            throw new InvalidOperationException(nameof(_isInit));

        _mover?.Update(Time.deltaTime);
    }

    public void SetMover(IMover mover)
    {
        _mover?.StopMove();
        _mover = mover;
        _mover.StartMove();
    }
}
