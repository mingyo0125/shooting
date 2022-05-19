using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;

    public GameObject bulletFactory2;
    public Transform firePos;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(bulletFactory);
            bullet.transform.position = firePos.position;
        }
    }

    private void Start()
    {
        StartCoroutine(delay());
    }

    IEnumerator delay()
    {
        while (true)
        {
        if (Input.GetMouseButtonDown(1))
        {   
            GameObject bullet2 = Instantiate(bulletFactory2);
            bullet2.transform.position = firePos.position;
            yield return new WaitForSeconds(3);
        }
            yield return null;
        }
    }
    
}
