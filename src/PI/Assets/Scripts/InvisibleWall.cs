using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleWall : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {   
        TeleportObjectToZero(collision.gameObject);
    }

    void TeleportObjectToZero(GameObject objeto)
    {
        objeto.transform.position = new Vector3(5.0f, 2.0f, 0.0f);
    }
}
