using System.Collections;
using System.Collections.Generic;
using UnityEngine;using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StartController : MonoBehaviour
{
    
    void Start()
    {
       

            GetComponent<Button>().onClick.AddListener(() =>
            {
                ClickEvent();
            });
        
    }

    // Update is called once per frame
    void ClickEvent()
	{
        mobile.mobileTF = true;
        mobile.jumpTF = true;
        SceneManager.LoadScene(1);
	}

	void Update()
	{
		
	}
}
