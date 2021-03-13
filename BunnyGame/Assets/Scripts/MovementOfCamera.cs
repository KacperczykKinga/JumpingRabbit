using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementOfCamera : MonoBehaviour
{
  
    public float moveSpeed = 0.00000001f;
    public GameObject rabbit;
    public bool falling = true;
    private Vector3 offset;
    private int specialNumberToStopCamera = GeneratingBlocks.lengthOfHole / 2;
    public GameObject level, goToTheHoole;
    private bool firstCameraState = true;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - rabbit.transform.position;
        goToTheHoole.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        int wholeLengthOfLevel = GeneratingBlocks.lengthOfLevel + GeneratingBlocks.moreBlocks;
        ///spadanie królika
        if ((rabbit != null && rabbit.transform.position.y > 0 && falling))
        {
            transform.position = new Vector3(0, rabbit.transform.position.y, rabbit.transform.position.z + offset.z);
            level.gameObject.SetActive(true);
        }
        ///podązanie za królikiem
        else if (rabbit != null && rabbit.transform.position.x > GetComponent<Rigidbody2D>().transform.position.x && Health.health > 0 && (GetComponent<Rigidbody2D>().transform.position.x + specialNumberToStopCamera < wholeLengthOfLevel))
        {
            transform.position = new Vector3(rabbit.transform.position.x, GetComponent<Rigidbody2D>().transform.position.y, rabbit.transform.position.z + offset.z);
            level.gameObject.SetActive(false);
        }
        ///stanięcie kamery
        else if (GetComponent<Rigidbody2D>().transform.position.x + specialNumberToStopCamera > wholeLengthOfLevel) 
        {
            transform.position = new Vector3(wholeLengthOfLevel - specialNumberToStopCamera, GetComponent<Rigidbody2D>().transform.position.y, GetComponent<Rigidbody2D>().transform.position.z);
            level.gameObject.SetActive(false);
            if (Health.health > 0)
            {
                goToTheHoole.gameObject.SetActive(true);
            }
            else
            {
                goToTheHoole.gameObject.SetActive(false);
            }
        }
        ///uciekanie kamery
        else
        {
            if ( rabbit != null && rabbit.transform.position.x < 0 && firstCameraState)
            {
                transform.position = new Vector3(0, 0, GetComponent<Rigidbody2D>().transform.position.z);
            }
            else
            {
                firstCameraState = false;
                GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, 0);
            }
            falling = false;
            level.gameObject.SetActive(false);
        }

    }
}
