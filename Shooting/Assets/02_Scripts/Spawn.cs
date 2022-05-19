using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);
        Invoke("Spawn_", 30f);
    }

    void Spawn_()
    {
        gameObject.SetActive(true);

    }

}

