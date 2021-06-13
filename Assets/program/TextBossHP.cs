using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextBossHP : MonoBehaviour
{
    [SerializeField]
    public static int BossHealthCurrent;
    public int BossHealthMax;
    private Image BosshealthBar;
    // Start is called before the first frame update
    void Start()
    {
        BosshealthBar = GetComponent<Image>();
        BossHealthCurrent = BossHealthMax;
    }

    // Update is called once per frame
    void Update()
    {
        BosshealthBar.fillAmount = (float)BossHealthCurrent / (float)BossHealthMax;
    }

}
