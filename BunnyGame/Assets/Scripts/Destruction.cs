using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    public GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D thisObject = GetComponent<Rigidbody2D>();
        if (thisObject.transform.position.x < camera.transform.position.x - 12)
        {
            Destroy(thisObject);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        //if (coll.gameObject.name == "bomb")
        //{
        //    Destroy(coll.gameObject);
        //    this.GetComponent<healthScript>().health -= 1;
        //}
    }
}
