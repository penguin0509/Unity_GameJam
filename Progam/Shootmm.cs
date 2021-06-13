using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
public class Shootmm : MonoBehaviour
{
    [SerializeField]
    public GameObject Bullet2;
    public static bool ShootmmTF = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (ShootmmTF == true)
        {
            Invoke("SpawnBullet", 1);
        }
    }

    void SpawnBullet()
    {
        Instantiate(Bullet2, transform.position, transform.rotation);
    }

}
