using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotInCamera : MonoBehaviour
{
    public GameObject camera;
    private int toBottom = 5;
    private int toFarInLeft = 18;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((GetComponent<Rigidbody2D>().position.y + toBottom < camera.transform.position.y)  ||  (GetComponent<Rigidbody2D>().position.x < camera.transform.position.x - toFarInLeft))
        {
            Health.health = 0;
        }
    }
}
