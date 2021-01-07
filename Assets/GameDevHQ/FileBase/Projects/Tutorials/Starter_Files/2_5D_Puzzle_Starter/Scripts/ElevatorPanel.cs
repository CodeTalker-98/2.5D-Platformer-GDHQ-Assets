using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPanel : MonoBehaviour
{
    [SerializeField] private MeshRenderer _elevatorLight;
    private bool _elevatorEnable = false;

    private void Update()
    {
        if (_elevatorEnable)
        {
            if (Input.GetKeyDown(KeyCode.E))
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
