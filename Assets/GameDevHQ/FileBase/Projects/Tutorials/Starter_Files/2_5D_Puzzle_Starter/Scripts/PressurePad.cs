using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePad : MonoBehaviour
{
    [SerializeField] private float _tolerance = 0.05f;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Moveable")
        {
            float distance = Vector3.Distance(transform.position, other.transform.position);

            if (distance < _tolerance)
            {
                Rigidbody moveable = other.GetComponent<Rigidbody>();

                if (moveable != null)
                {
                    moveable.isKinematic = true;
                }

                MeshRenderer renderer = GetComponentInChildren<MeshRenderer>();

                if (renderer != null)
                {
                    renderer.material.color = Color.green;
                }

                Destroy(this);
            }
        }
    }
}
