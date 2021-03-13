using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratingBlocks : MonoBehaviour
{
    public  GameObject  oneGrass;
    public  GameObject  oneRock;
    public  GameObject  oneHole;
    public  GameObject  oneSand;
    private float       startX                  = -12f;
    private float       startY                  = -4.5f;
    private int         startingGround          = 12;
    private float       firstLevelY             = -1.7f;
    private float       secondLevelY            = 1.1f;
    private float       ceilingLevel            = 5f;
    private float       startXToGenerate;
    public  static int  lengthOfLevel           = 100;
    private float       lengthToCentreOfGrass   = 0.7f;
    public  static int  moreBlocks              = 10;
    private float       forHole                 = 0.45f;
    public  static int  lengthOfSand            = 21;
    public  static int  lengthOfHole            = 21;
    private int         lengthHoleFromEnd       = 6;


    // Start is called before the first frame update
    void Start()
    {
        this.baseGrass();
        this.generateGrassAndRocks();
        this.generateCeiling();
        this.generateBackground();
    }

    // Update is called once per frame
    void Update()
    {

    }



    //generate first blocks on ZeroLevel
    void baseGrass()
    {
        for (int i = 0; i < startingGround; i++)
        {
            GameObject grass = Instantiate(oneGrass);
            grass.transform.position = new Vector2(startX + i, startY);
        }
    }



    //generate blocks on various levels and rocks on these blocks
    void generateGrassAndRocks()
    {
        startXToGenerate = startX + startingGround;
        

        while (startXToGenerate < lengthOfLevel)
        {

            int randomLevelY = Random.Range(0, 3);
            int randomLengthX = Random.Range(2, 6);

            for (int k = 0; k < randomLengthX; k++)
            {
                GameObject grass = Instantiate(oneGrass);

                if (randomLevelY == 0)
                {
                    grass.transform.position = new Vector2(startXToGenerate, startY);
                }
                else if (randomLevelY == 1)
                {
                    grass.transform.position = new Vector2(startXToGenerate, firstLevelY);
                }
                else
                {
                    grass.transform.position = new Vector2(startXToGenerate, secondLevelY);
                }

                if (Random.Range(0, 5) == 1)
                {
                    GameObject rock = Instantiate(oneRock);

                    if (randomLevelY == 0)
                    {
                        rock.transform.position = new Vector2(startXToGenerate, startY + lengthToCentreOfGrass);
                    }
                    else if (randomLevelY == 1)
                    {
                        rock.transform.position = new Vector2(startXToGenerate, firstLevelY + lengthToCentreOfGrass);
                    }
                    else
                    {
                        Destroy(rock);
                    }
                }

                

                startXToGenerate ++;

            }

        }
        float endOfLevel = startXToGenerate + moreBlocks;

        while(startXToGenerate < endOfLevel)
        {
            GameObject grass = Instantiate(oneGrass);
            grass.transform.position = new Vector2(startXToGenerate, startY);
            startXToGenerate ++;
        }

        GameObject hole = Instantiate(oneHole);
        hole.transform.position = new Vector2(startXToGenerate - lengthHoleFromEnd, startY + forHole);
    }



    //generate blocks of ceiling
    void generateCeiling()
    {
        float startXForCeiling = startX + lengthOfHole;
        while (startXForCeiling <= lengthOfLevel + moreBlocks)
        {
            GameObject grass = Instantiate(oneGrass);
            grass.transform.position = new Vector2(startXForCeiling, ceilingLevel);
            startXForCeiling ++;
        }
    }

    void generateBackground()
    {
        float startForBackground = 0f;
        while (startForBackground - lengthOfSand/2 <= lengthOfLevel + moreBlocks)
        {
            GameObject sand = Instantiate(oneSand);
            sand.transform.position = new Vector2(startForBackground, 0);
            startForBackground += lengthOfSand;
        }
    }
}
