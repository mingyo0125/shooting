using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    float speed = 5;    
    Vector3 dir;

    private void Start()
    {
        int rd = UnityEngine.Random.Range(0, 10);
        if (rd<3)
        {
            GameObject target = GameObject.Find("Player");
            dir = target.transform.position - transform.position;
            dir.Normalize();

        }
        else
        {
            dir = Vector3.down;
        }
    }
    void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime);
    }

    public void OnCollisionEnter(Collision collision)
    {

            if(collision.gameObject.CompareTag("Bullet2"))
            {
                gameObject.SetActive(false);
            }
            
            if(collision.gameObject.CompareTag("Bullet"))
            {
                gameObject.SetActive(false);
                collision.gameObject.SetActive(false);
            }

        if(collision.gameObject.CompareTag("Player"))
        {
            Invoke("gameover",0.7f);
            gameObject.SetActive(false);
            collision.gameObject.SetActive(false);
        }
        }
    public void gameover()
    {
        SceneManager.LoadScene("GameOver");
    }
    }
