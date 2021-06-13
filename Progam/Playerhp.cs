using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Playerhp : MonoBehaviour
{
    [SerializeField]
    public int HP = 10;
    public int damage = 1;
    private SpriteRenderer sr;
    private Color RedColor;
    public float flashTime;
    private Animator myAnim1;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        RedColor = sr.color;
        myAnim1 = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            mobile.mobileTF = true;
            mobile.jumpTF = true;
            myAnim1.SetBool("Died", true);
            Invoke("Died", 3);
        }
    }


    void Died()
    {
        SceneManager.LoadScene("Game_menu");
    }
    void FlashColor(float time)
    {
        sr.color = Color.red;
        Invoke("ResetColor", time);
    }

    void TakeDamage()
    {
        TextHP.HealthCurrent--;
        HP--;
        FlashColor(flashTime);

    }

    void ResetColor()
    {
        sr.color = RedColor;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            TakeDamage();
        }
    }
}
