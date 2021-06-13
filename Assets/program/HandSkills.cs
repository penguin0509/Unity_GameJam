using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandSkills : MonoBehaviour
{
    [SerializeField]
    public int HP = 5;
    public int damage = 1;
    private SpriteRenderer sr;
    private Color RedColor;
    public float flashTime;
    public static bool TF;
    public float speed;
    public float radius;

    private Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        RedColor = sr.color;
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
        }

        if (TF == true)
        {
            HP--;
            FlashColor(flashTime);
            TF = false;
        }

        if (playerTransform != null)
        {
            float distance = (transform.position - playerTransform.position).sqrMagnitude;

            if (distance < radius)
            {
                transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
            }
        }
    }
    void FlashColor(float time)
    {
        sr.color = Color.red;
        Invoke("ResetColor", time);
    }


    void ResetColor()
    {
        sr.color = RedColor;
    }
}
