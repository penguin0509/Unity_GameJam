using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
public class Shootweapon : MonoBehaviour
{
    public float speed;
    public float rotatespeed;

    private Rigidbody2D rb2d;
    private Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        speed = 15;
        transform.Rotate(0, 0, rotatespeed);
        Invoke("Delect", 1);
    }

    void Delect()
    {
        Destroy(gameObject);
    }
}
