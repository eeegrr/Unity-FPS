using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float spinningSpeed = 50.0f;

    void Update()
    {

        transform.Rotate(new Vector3(0f, 0f, spinningSpeed) * Time.deltaTime, Space.Self);
        


    }
}
