using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arena : MonoBehaviour {

    public GameObject water;
    public Island[] islands;
    public Enemy[] pesawatMusuh;

    private float generateIslandDelayCount;
    private float generateEnemyDelayCount;
    private Vector2 minPosition, maxPosition;

	// Use this for initialization
	void Start () {
        minPosition = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        maxPosition = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        float waterPosX = minPosition.x, waterPosY = minPosition.y;

        SpriteRenderer instWater = (Instantiate(water, new Vector2(waterPosX, waterPosY), Quaternion.identity) as GameObject).GetComponent<SpriteRenderer>();
        instWater.transform.parent = this.transform;
        while(waterPosY - 2 * instWater.sprite.bounds.max.y < maxPosition.y)
        {
            waterPosX = minPosition.x;
            while(waterPosX - 2 * instWater.sprite.bounds.max.x < maxPosition.x)
            {
                instWater = (Instantiate(water, new Vector2(waterPosX, waterPosY), Quaternion.identity) as GameObject).GetComponent<SpriteRenderer>();
                instWater.transform.parent = this.transform;
                waterPosX += 2 * instWater.sprite.bounds.max.x;
            }
            waterPosY += 2 * instWater.sprite.bounds.max.y;
        }
	}
	
	// Update is called once per frame
	void Update () {
        generateIslandDelayCount -= Time.deltaTime;
        if(generateIslandDelayCount <= 0)
        {
            Instantiate(islands[Random.Range(0, islands.Length - 1)], new Vector2(Random.Range(minPosition.x, maxPosition.x), 20), Quaternion.identity);
            generateIslandDelayCount = Random.Range(5, 15);
        }

        generateEnemyDelayCount -= Time.deltaTime;
        if(generateEnemyDelayCount <= 0)
        {
            Instantiate(pesawatMusuh[Random.Range(0, pesawatMusuh.Length - 1)], new Vector2(Random.Range(minPosition.x, maxPosition.x), 20), Quaternion.identity);
            generateEnemyDelayCount = Random.Range(3, 10);
        }
	}
}
