using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peluru : MonoBehaviour {

    public int scoreValue = 10;
    public GameObject explosion;
    private GameController gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if(gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    // Update is called once per frame
    void Update () {
        this.transform.Translate(new Vector2(0, 10) * Time.deltaTime);
        if(this.transform.position.y > 20)
        {
            Destroy(this.gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            GameObject expl = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
            Destroy(col.gameObject);
            Destroy(expl, 3);

            Destroy(this.gameObject);

            gameController.AddScore(scoreValue);
        }
    }
}
