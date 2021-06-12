using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
public class Shoot : MonoBehaviour
{
    [SerializeField]
    public GameObject Cube;
    public Vector3 worldPosition;
    public bool qeTF = false;

    private LineRenderer lr;
    private Vector3 grapplePoint;

    public Transform guntip;
    public float step;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        lr = Cube.gameObject.AddComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && qeTF == false)
        {
            Debug.Log("true");
            lr.SetWidth(0.03f, 0.03f);
            qeTF = true;
        }
        else if (Input.GetKeyDown(KeyCode.E) && qeTF == true)
        {
            Debug.Log("false");
            lr.SetWidth(0.00f, 0.00f);
            qeTF = false;
        }
        
        
        if (Input.GetMouseButton(0) && qeTF == true)
        {
            CheckMoblie();
            ShootRope();
            mobile.jumpTF = true;
        }
        else
        {
            mobile.jumpTF = false;
            lr.SetWidth(0.00f, 0.00f);
        }
    }

    void CheckMoblie()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPosition.x += 8;
        float step = speed * Time.deltaTime;
        Cube.transform.localPosition = new Vector3(worldPosition.x, worldPosition.y, 11.713f);
        lr.SetWidth(0.03f, 0.03f);

    }

    void ShootRope()
    {

        lr.SetPosition(0, guntip.position);
        lr.SetPosition(1, worldPosition);
    }
}
