using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class WASDMovement : NetworkBehaviour
{
    private Vector3 movementDelta = Vector3.zero;
    public float speed = 10f;

    private void Update()
    {
        if (!IsOwner)
            return;

        movementDelta.x = Input.GetAxis("Horizontal");
        movementDelta.z = Input.GetAxis("Vertical");

        transform.Translate(movementDelta * Time.deltaTime * -speed);
    }
}
