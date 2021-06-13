using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
public class TextBattery2 : MonoBehaviour
{
    [SerializeField]
    public static int BatteryCurrent2;

    public static bool BatteryDownTF2 = false;
    public static bool BatteryUpTF2 = false;
    public int BatteryMax2;
    private Image BatteryBar2;
    void Start()
    {
        BatteryBar2 = GetComponent<Image>();
        BatteryCurrent2 = BatteryMax2;
    }

    // Update is called once per frame
    void Update()
    {
        BatteryBar2.fillAmount = (float)BatteryCurrent2 / (float)BatteryMax2;
        if (BatteryDownTF2 == true)
        {
            InvokeRepeating("DownBattery2", 1, 1);
        }

        if (BatteryUpTF2 == true)
        {
            InvokeRepeating("UpBattery2", 1, 1);
        }
    }



    void DownBattery2()
    {
        BatteryCurrent2 -= 10;
        this.CancelInvoke();
        if (BatteryCurrent2 <= 0)
        {
            BatteryCurrent2 = 0;
            BatteryDownTF2 = false;
            this.CancelInvoke();
        }

    }

    void UpBattery2()
    {
        BatteryCurrent2 += 10;
        this.CancelInvoke();

        if (BatteryCurrent2 <= 100 && BatteryCurrent2 > 10)
        {
            if (BatteryCurrent2 >= 100)
            {
                BatteryCurrent2 = 100;
                BatteryUpTF2 = false;
                this.CancelInvoke();
            }
        }
    }
}