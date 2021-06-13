using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShootRope : MonoBehaviour
{
    [SerializeField]
    public GameObject Cube1;
    public GameObject Cube2;
    public GameObject Cube3;
    public GameObject Cube4;
    public GameObject weapon1;
    public GameObject weapon2;
    public GameObject Bullet;

    public static bool Cube1TF;
    public static bool Cube2TF;
    public static bool Cube3TF;
    public static bool Cube4TF;
    public static bool weapon1TF;
    public static bool weapon2TF;


    public float BulletSpeed;

    public Transform ShootPoint;

    Vector2 Direction;

    public LineRenderer line;
    GameObject target;

    public static bool ShootTF = true;

    public SpringJoint2D spring;  
    // Start is called before the first frame update
    void Start()
    {
        line.enabled = false;
        spring.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Direction = MousePos - (Vector2)transform.position;

        FaceMouse();

        if (Input.GetMouseButtonDown(0) && ShootTF == true)
        {
            ShootTF = false;
            Shoot();
        }
        
        if (Textenergy.EnergyCurrent <= 0)
        {
            Release();
            Cube2TF = false;
            Cube4TF = false;
            Cube1TF = false;
            Cube3TF = false;
            weapon1TF = false;
            weapon2TF = false;
            mobile.mobileTF = false;
            mobile.jumpTF = false;
            ShootTF = true;
            Textenergy.EnergyUpTF = true;
            Textenergy.EnergyDownTF = false;
        }

        if (Input.GetMouseButtonDown(1))
        {
            Release();
            Cube2TF = false;
            Cube4TF = false;
            Cube1TF = false;
            Cube3TF = false;
            weapon1TF = false;
            weapon2TF = false;
            mobile.mobileTF = false;
            mobile.jumpTF = false;
            ShootTF = true;
            Textenergy.EnergyUpTF = true;
            Textenergy.EnergyDownTF = false;
        }

        if (target != null)
        {
            if (Cube1TF == true)
            {
                Textenergy.EnergyUpTF = false;
                Textenergy.EnergyDownTF = true;
                mobile.jumpTF = true;
                mobile.mobileTF = true;
                line.SetPosition(0, ShootPoint.position);
                line.SetPosition(1, target.transform.position);
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                worldPosition.x += 8;
                Cube1.transform.localPosition = new Vector3(worldPosition.x, worldPosition.y, 11.713f);
            }
            else if (Cube2TF == true)
            {
                Textenergy.EnergyUpTF = false;
                Textenergy.EnergyDownTF = true;
                mobile.jumpTF = true;
                mobile.mobileTF = true;
                line.SetPosition(0, ShootPoint.position);
                line.SetPosition(1, target.transform.position);
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                worldPosition.x += 8;
                Cube2.transform.localPosition = new Vector3(worldPosition.x, worldPosition.y, 11.713f);
            }
            else if (Cube3TF == true)
            {
                Textenergy.EnergyUpTF = false;
                Textenergy.EnergyDownTF = true;
                mobile.jumpTF = true;
                mobile.mobileTF = true;
                line.SetPosition(0, ShootPoint.position);
                line.SetPosition(1, target.transform.position);
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                worldPosition.x += 8;
                Cube3.transform.localPosition = new Vector3(worldPosition.x, worldPosition.y, 11.713f);
            }
            else if (Cube4TF == true)
            {
                Textenergy.EnergyUpTF = false;
                TextBattery.BatteryDownTF = true;
                Textenergy.EnergyDownTF = true;
                mobile.jumpTF = true;
                mobile.mobileTF = true;
                line.SetPosition(0, ShootPoint.position);
                line.SetPosition(1, target.transform.position);
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                worldPosition.x += 8;
                Cube4.transform.localPosition = new Vector3(worldPosition.x, worldPosition.y, 11.713f);
            }
            else if (weapon1TF == true)
            {
                Textenergy.EnergyUpTF = false;
                Textenergy.EnergyDownTF = true;
                mobile.jumpTF = true;
                mobile.mobileTF = true;
                line.SetPosition(0, ShootPoint.position);
                line.SetPosition(1, target.transform.position);
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                worldPosition.x += 8;
                weapon1.transform.localPosition = new Vector3(worldPosition.x, worldPosition.y, 11.713f);


            }
            else if (weapon2TF == true)
            {
                Textenergy.EnergyUpTF = false;
                Textenergy.EnergyDownTF = true;
                mobile.jumpTF = true;
                mobile.mobileTF = true;
                line.SetPosition(0, ShootPoint.position);
                line.SetPosition(1, target.transform.position);
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                worldPosition.x += 8;
                weapon2.transform.localPosition = new Vector3(worldPosition.x, worldPosition.y, 11.713f);
            }
        }
    }

    void FaceMouse()
    {
        transform.right = Direction;
    }

    void Shoot()
    {
        
        GameObject BulletIns =  Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(transform.right * BulletSpeed);


    }

    public void TargetHit(GameObject hit)
    {
        target = hit;
        line.enabled = true;
        spring.enabled = true;
        spring.connectedBody = target.GetComponent<Rigidbody2D>();
    }

    void Release()
    {
        line.enabled = false;
        spring.enabled = false;
        target = null;
    }

}
