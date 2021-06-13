using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BossRandomFly : MonoBehaviour
{
    [SerializeField]
    public GameObject Left;
    public GameObject Right;
    public int HP = 1;
    public int damage = 1;
    private SpriteRenderer sr;
    private Color RedColor;
    public float flashTime;

    public bool skillsTF;
    public float speed;
    public float startWaitTime;
    private float waitTime;
    public float X;
    public float Y;

    public Transform movePos;
    public Transform leftDownPos;
    public Transform rightUpPos;
    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
        movePos.position = GetRandomPos();
        sr = GetComponent<SpriteRenderer>();
        RedColor = sr.color;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, movePos.position, speed * Time.deltaTime);

        if (HP <= 0)
        {
            Invoke("Died", 5);
        }

        if (Vector2.Distance(transform.position, movePos.position) < 0.1f)
        {
            if (waitTime <= 0.1)
            {
                movePos.position = GetRandomPos();
                waitTime = startWaitTime;
            }
            else
            {
                waitTime = Time.deltaTime;
            }
        }
        if (skillsTF == true)
        {
            skillsTF = false;
            X = Random.Range(-7.28f, 8.16f);
            Y = Random.Range(-6.00f, 9.00f);
            Instantiate(Left, new Vector3(X, 3.4f, 0), new Quaternion(0, 0, 0, 0));
            Instantiate(Right, new Vector3(Y, 3.4f, 0), new Quaternion(0, 0, 0, 0));
        }
       
    }

       void Died()
    {
        SceneManager.LoadScene("Game_menu");
    }
        Vector2 GetRandomPos()
        {
            Vector2 rndPos = new Vector2(Random.Range(-9f, 10f), Random.Range(-2f, 2f));
            return rndPos;
        }

        void FlashColor(float time)
        {
                sr.color = Color.red;
                Invoke("ResetColor", time);
        }

        void TakeDamage()
        {
        TextBossHP.BossHealthCurrent--;
        HP--; ;
        FlashColor(flashTime);
        skillsTF = true; ;

        }


        void ResetColor()
        {
            sr.color = RedColor;
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Bullet"))
            {
                TakeDamage();
            }
        }


    
}
