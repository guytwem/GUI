using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    [SerializeField] float slowSpeed = 1f;
    [SerializeField] float faceingAngle = 30f;

    private void Update()
    {
        float spee = speed;
        if (Vector3.Angle(transform.forward, -Camera.main.transform.forward) < faceingAngle)
        {
            spee = slowSpeed;
        }

        transform.Rotate(Vector3.up * spee);
    }





}
