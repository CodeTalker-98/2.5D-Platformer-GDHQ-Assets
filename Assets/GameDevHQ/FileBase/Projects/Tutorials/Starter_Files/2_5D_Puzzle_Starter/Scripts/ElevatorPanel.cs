using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPanel : MonoBehaviour
{
    [SerializeField] private int _operationPrice = 8; 
    [SerializeField] private MeshRenderer _elevatorLight;
    private bool _elevatorEnable = false;
    private bool _elevatorCalled = false;
    private Player _player;
    private Elevator _elevator;

    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _elevator = GameObject.Find("Elevator").GetComponent<Elevator>();

        if (_player == null)
        {
            Debug.LogError("The PLAYER is NULL");
        }
    }

    private void Update()
    {
        if (_elevatorEnable)
        {
            if (Input.GetKeyDown(KeyCode.E) && _player.CheckCoins() >= _operationPrice)
            {
                if (_elevatorCalled)
                {
                    _elevatorLight.material.color = Color.red;
                    _elevatorCalled = false;
                }
                else
                {
                    _elevatorLight.material.color = Color.green;
                    _elevatorCalled = true;
                }
                if (_elevator != null)
                {
                    _elevator.CallElevator();
                }
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            _elevatorEnable = true;  
        }
    }
}
