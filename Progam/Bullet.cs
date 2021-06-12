using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bullet : MonoBehaviour
{

    ShootRope gun;
    // Start is called before the first frame update
    void Start()
    {
        gun = GameObject.FindGameObjectWithTag("Gun").GetComponent<ShootRope>();
    }

    // Update is called once per frame
     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "weapon")
        {
            gun.TargetHit(other.gameObject);
            ShootRope.weapon1TF = true;
            ShootRope.ShootTF = false;
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "weapon1")
        {
            gun.TargetHit(other.gameObject);
            ShootRope.ShootTF = false;
            ShootRope.weapon2TF = true;
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Ground")
        {
            gun.TargetHit(other.gameObject);
            ShootRope.ShootTF = false;
            ShootRope.Cube1TF = true;
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Ground2")
        {
            gun.TargetHit(other.gameObject);
            ShootRope.ShootTF = false;
            ShootRope.Cube2TF = true;
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Ground3")
        {
            gun.TargetHit(other.gameObject);
            ShootRope.ShootTF = false;
            ShootRope.Cube3TF = true;
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "leftRight")
        {
            ShootRope.ShootTF = true;
            Destroy(gameObject);
        }
    }
}
