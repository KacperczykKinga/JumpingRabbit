using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratingCards : MonoBehaviour
{
    public GameObject   rabbit;
    public GameObject   oneQueen;
    public GameObject   oneKing;
    public GameObject   oneJack;
     
    private float       firstLevelY         = -2.9f;
    private float       secondLevelY        = -0.3f;
    private float       thirdLevelY         = 2.7f;
    private int         moreThanCameraWidth = 23;
    private int         lastRandomCard      = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // while ()
        //{

        int randomCard = Random.Range(0, 3);
       
        
        if (Random.Range(0,250) == 1 && rabbit != null && lastRandomCard != randomCard)
        {
            GameObject oneCard;
            if (randomCard == 0)
            {
                oneCard = Instantiate(oneQueen);
                oneCard.transform.position = new Vector2(rabbit.transform.position.x + moreThanCameraWidth, firstLevelY);
            }
            else if(randomCard == 1)
            {
                oneCard = Instantiate(oneJack);
                oneCard.transform.position = new Vector2(rabbit.transform.position.x + moreThanCameraWidth, secondLevelY);
            }
            else
            {
                oneCard = Instantiate(oneKing);
                oneCard.transform.position = new Vector2(rabbit.transform.position.x + moreThanCameraWidth, thirdLevelY);
            }
            lastRandomCard = randomCard;
        }


    }
    
}
