using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour
{
    float speed = 5;
    public int dmg;
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
