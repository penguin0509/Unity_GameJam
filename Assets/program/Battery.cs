using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Battery : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "weapon" )
        {
                TextBattery.BatteryUpTF = false;
                TextBattery.BatteryDownTF = true;
                weapon.CheckBatteryWeapon = true;
        }

        if (other.gameObject.tag == "weapon1")
        {
            TextBattery.BatteryUpTF = false;
            TextBattery.BatteryDownTF = true;
            weapon.CheckBatteryWeapon = true;
        }
    }
}
