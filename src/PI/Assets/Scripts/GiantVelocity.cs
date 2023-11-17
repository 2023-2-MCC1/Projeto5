using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantVelocity : MonoBehaviour
{

    public float speed;

    // Update is called once per frame
    void Update()
    {
        // Alteramos o eixo x e z pois o Giant precisa ir na diagonal para colidir com a vila
        transform.position += new Vector3(-1f, 0.0f, 0.9f) * speed * Time.deltaTime;
    }

}
