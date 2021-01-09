using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private Transform _targetA, _targetB;
    private bool _goingDown = false;

    private void Start()
    {
        transform.position = _targetA.position;
    }

    void FixedUpdate()
    {
        if (_goingDown)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetB.position, _speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetA.position, _speed * Time.deltaTime);
        }
    }

    public void CallElevator()
    {
        _goingDown = !_goingDown;
    }
}
