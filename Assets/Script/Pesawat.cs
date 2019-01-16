using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pesawat : MonoBehaviour {

    public float speed = 10;
    public Transform [] missileLaunchers;
    public peluru missile;
    public float attackDelay = 0.5f;
    public bool limitMove = true;

    private Vector2 minPosition, maxPosition;
    private float attackDellayCounter;

    public bool paused;

	// Use this for initialization
	void Start () {
        minPosition = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        maxPosition = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
	}
	
	// Update is called once per frame
	void Update () {
        attackDellayCounter -= Time.deltaTime;
	}

    public void MoveUp()
    {
        if (limitMove)
        {
            Vector2 newPosition = (Vector2)this.transform.position + Vector2.up * speed * Time.deltaTime;
            if(newPosition.y < maxPosition.y)
            {
                this.transform.position = newPosition;
            }
            else
            {
                this.transform.Translate(Vector2.up * speed * Time.deltaTime);
            }
        }
    }

    public void MoveDown()
    {
        if (limitMove)
        {
            Vector2 newPosition = (Vector2)this.transform.position - Vector2.up * speed * Time.deltaTime;
            if(newPosition.y > minPosition.y)
            {
                this.transform.position = newPosition;
            }
        }
    }

    public void MoveLeft()
    {
        if (limitMove)
        {
            Vector2 newPosition = (Vector2)this.transform.position - Vector2.right * speed * Time.deltaTime;
            if(newPosition.x > minPosition.x)
            {
                this.transform.position = newPosition;
            }
        }
    }

    public void MoveRight()
    {
        if (limitMove)
        {
            Vector2 newPosition = (Vector2)this.transform.position + Vector2.right * speed * Time.deltaTime;
            if(newPosition.x < maxPosition.x)
            {
                this.transform.position = newPosition;
            }
        }
    }

    public void Attack()
    {
        if(attackDellayCounter <= 0)
        {
            foreach(Transform missileLauncher in missileLaunchers)
            {
                Instantiate(missile, missileLauncher.position, missileLauncher.rotation);
            }
            attackDellayCounter = attackDelay;
        }
    }

    void OnGUI()
    {
        if (paused)
        {
            GUI.Box(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 250, 40), "GAME PAUSED");
        }
    }
    void OnApplicationPause(bool pauseStatus)
    {
        paused = pauseStatus;
    }

}
