using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
public class weapon : MonoBehaviour
{
    Vector2 Direction;
    public static bool CheckBatteryWeapon = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Direction = MousePos - (Vector2)transform.position;

        FaceMouse();

        if (CheckBatteryWeapon == true)
        {
            Shootmm.ShootmmTF = true;
        }
        else if (CheckBatteryWeapon == false)
        {
            Shootmm.ShootmmTF = false ;
        }
    }

    void FaceMouse()
    {
        transform.right = Direction;
    }



}
