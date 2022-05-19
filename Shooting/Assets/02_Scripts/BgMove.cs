using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMove : MonoBehaviour
{
    public float speed = 0.2f;
    public Material bg;
    void Update()
    {
        Vector2 dir = Vector2.up;
        bg.mainTextureOffset += dir * speed * Time.deltaTime;
    }
}
