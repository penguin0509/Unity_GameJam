using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Textenergy : MonoBehaviour
{
    [SerializeField]
    public static int EnergyCurrent;

    public static bool EnergyDownTF = false;
    public static bool EnergyUpTF = false;
    public int EnergyMax;
    private Image EnergyBar;
    // Start is called before the first frame update
    void Start()
    {
        EnergyBar = GetComponent<Image>();
        EnergyCurrent = EnergyMax;
    }

    // Update is called once per frame
    void Update()
    {
        EnergyBar.fillAmount = (float)EnergyCurrent / (float)EnergyMax;
        if (EnergyDownTF == true)
        {
            InvokeRepeating("DownEnergy", 1, 1);
        }
        else if (EnergyUpTF == true)
        {
            InvokeRepeating("UpEnergy", 1, 1);
        }
    }

    void DownEnergy()
    {
        EnergyCurrent -= 1;
        if (EnergyUpTF == true)
        {
            InvokeRepeating("UpEnergy", 1, 1);
        }

        if (EnergyCurrent <= 0)
        {
            EnergyDownTF = false;
            EnergyCurrent = 0;
            this.CancelInvoke();
        }

    }

    void UpEnergy()
    {
        EnergyCurrent += 1;
        if(EnergyDownTF == true)
        {
            InvokeRepeating("DownEnergy", 1, 1);
        }

        if (EnergyCurrent >= 100)
        {
            EnergyUpTF = false;
            EnergyCurrent = 100;
            this.CancelInvoke();
        }
    }

}
