using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    [SerializeField]
    public float amount;
    public float speed;
    public int health;
    public string enemyName;
    public Sprite[] sprites;
    public float currentTime;
    public float deltaTime = 2f;
    public Slider slider;
    public float damage;

    public float damage2;
    public GameObject explosionFactory;

    SpriteRenderer spriteRenderer;

    Animator ani;
    Rigidbody rigid;
    private void Start()
    {
        amount = Random.Range(-5f,5f);
        speed = 3f;
    }
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if(enemyName == "B")
        {
            ani = GetComponent<Animator>();
        }

        rigid = GetComponent<Rigidbody>();
        rigid.velocity = Vector2.down * speed;
    }
    private void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > deltaTime)
        {
            amount = Random.Range(-5f,5f);
            currentTime = 0;
        }
        if (transform.position.x >= 7.5f)
        {
            amount = Random.Range(-5f,0f);
        }
        else if (transform.position.x <= -7.5f)
        {
            amount = Random.Range(0f,5f);
        }
        transform.position += Vector3.right * speed * Time.deltaTime * amount;
        
    }
    

    void OnHit(int dmg)
    {
        health -= dmg;
        spriteRenderer.sprite = sprites[1];
        Invoke("ReturnSprite", 0.1f);

        if(enemyName == "B")
        {
            ani.SetTrigger("OnHit");
        }

        if(health <=0)
        {
            gameObject.SetActive(false);
            GameObject explosion = Instantiate(explosionFactory);
            explosion.transform.position = transform.position;
            Invoke("clear", 1f);
        }
    }

        void ReturnSprite()
        {
            spriteRenderer.sprite = sprites[0];
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.CompareTag("Bullet"))
            {
                Destroy(other.gameObject);
                Bullet bullet = other.gameObject.GetComponent<Bullet>();
                OnHit(bullet.dmg);
                slider.value -= damage;
            }
            else if (other.gameObject.CompareTag("Bullet2"))
            {
                Destroy(other.gameObject);
                Bullet2 bullet2 = other.gameObject.GetComponent<Bullet2>();
                OnHit(bullet2.dmg);
                slider.value -= damage2;
            }


            if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            GameObject explosion = Instantiate(explosionFactory);
            explosion.transform.position = transform.position;
            Invoke("die", 0.7f);
        }
        }
        
        public void die()
        {
            SceneManager.LoadScene("GameOver");
        }
        public void clear()
        {
            SceneManager.LoadScene("Clear");
        }
    }
