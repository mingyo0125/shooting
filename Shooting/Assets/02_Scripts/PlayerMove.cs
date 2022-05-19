using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;
    public float speed=5;
    public GameObject explosionFactory;
   
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(h,v,0);
        transform.position += dir * speed * Time.deltaTime;

    }
    private void OnCollisionEnter(Collision other)
    {

        if(other.gameObject.CompareTag("Enemy") ||
           other.gameObject.CompareTag("Boss"))
        {
            GameObject explosion = Instantiate(explosionFactory);
            explosion.transform.position = transform.position;
        }
    }
        private void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, stageData.LimitMin.x, stageData.LimitMax.x),
        Mathf.Clamp(transform.position.y, stageData.LimitMin.y, stageData.LimitMax.y));
    }



}
