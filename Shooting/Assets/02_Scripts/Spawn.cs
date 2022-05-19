using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossSpawn : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);
        Invoke("Spawn", 3f);
    }

    void Spawn()
    {
        gameObject.SetActive(true);

    }

}

