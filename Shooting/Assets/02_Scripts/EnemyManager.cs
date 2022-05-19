using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float EnemySpawnDelay;
    public Transform MinValue = null;
    public Transform MaxValue = null;
    public GameObject Enemy;

    void Start()
    {
        StartCoroutine(EnemyCreate());
    }

    public IEnumerator EnemyCreate()
    {
        while (true)
        {
                Instantiate(Enemy, new Vector2(Random.Range(MinValue.position.x, MaxValue.position.x), MaxValue.position.y), Quaternion.identity);
                yield return new WaitForSeconds(EnemySpawnDelay);
            }
            
        }
    }
