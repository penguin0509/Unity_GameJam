using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextBattery : MonoBehaviour
{
    [SerializeField]
    public static int BatteryCurrent;
    public static bool BatteryDownTF = false;
    public static bool BatteryUpTF = false;
    public int BatteryMax;
    private Image BatteryBar;
    void Start()
    {
        BatteryBar = GetComponent<Image>();
        BatteryCurrent = BatteryMax;
    }

    // Update is called once per frame
    void Update()
    {
        
        BatteryBar.fillAmount = (float)BatteryCurrent / (float)BatteryMax;
        if (BatteryDownTF == true)
        {
            InvokeRepeating("DownBattery", 1, 1);

        }

        if (BatteryUpTF == true )
        {
            InvokeRepeating("UpBattery", 1, 1);
        }
    }

  

    void DownBattery()
    {
        BatteryCurrent -= 20;
        this.CancelInvoke();
        if (BatteryCurrent <= 10)
        {
            this.CancelInvoke();
            BatteryCurrent = 0;
            BatteryDownTF = false;

        }

    }

    void UpBattery()
    {
        BatteryCurrent += 40;
        this.CancelInvoke();
        
            if (BatteryCurrent >= 100)
            {
                BatteryCurrent = 100;
                BatteryUpTF = false;
                this.CancelInvoke();
            }
        }
    }

   

