using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peluruMusuh : MonoBehaviour {

    public int HP_MinusValue = 1;
    private GameController gameController;
    public GameObject explosion;

    void Start()
    {
        this.transform.Rotate(180, 0, 180);
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }if (gameController == null)
        {
            Debug.Log("tidak menemukan script 'Game control' ");
        }
    }

    void Update()
    {
        this.transform.Translate(new Vector2(0, 6) * Time.deltaTime);
        if(this.transform.position.y < -20)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D colPlayer)
    {
       if(colPlayer.gameObject.tag == "Player")
        {
            gameController.MinHP(HP_MinusValue);
            GameObject expl = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
            Destroy(expl, 3);
            Destroy(this.gameObject);
        } 

    }
}
