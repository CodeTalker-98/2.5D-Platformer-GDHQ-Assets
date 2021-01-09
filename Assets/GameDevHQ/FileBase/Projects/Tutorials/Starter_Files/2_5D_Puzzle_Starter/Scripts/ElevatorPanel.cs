using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPanel : MonoBehaviour
{
    [SerializeField] private int _operationPrice = 8; 
    [SerializeField] private MeshRenderer _elevatorLight;
    private bool _elevatorEnable = false;
    private Player _player;

    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();

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
                _elevatorLight.material.color = Color.green;
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
