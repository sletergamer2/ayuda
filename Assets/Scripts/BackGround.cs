using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public float movPos;
    public GameObject backGround;
    public float maxY;

    public float fallVel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, fallVel * Time.deltaTime, 0);

        if(transform.position.y <= maxY)
        {
            transform.position = new Vector3(backGround.transform.position.x, movPos + backGround.transform.position.y, 990);
        }
    }
}
