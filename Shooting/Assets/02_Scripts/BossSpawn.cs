using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);
        Invoke("_Spawn", 3f);
    }

    void _Spawn()
    {
        gameObject.SetActive(true);

    }

}

