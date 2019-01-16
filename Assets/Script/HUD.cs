using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour {

    public Pesawat pesawat;

	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            pesawat.MoveUp();
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            pesawat.MoveDown();
        }
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) 
        {
            pesawat.MoveLeft();
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            pesawat.MoveRight();
        }
        if(Input.GetKey(KeyCode.Space))
        {
            pesawat.Attack();
        }
        // if(Input.GetKey(KeyCode.Z))
        // {
        //     pesawat.GamePaused();
        // }
	}
}
