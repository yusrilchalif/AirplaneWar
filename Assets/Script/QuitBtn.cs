﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitBtn : MonoBehaviour {

	public void OnClick(){
		Application.Quit();
		Debug.Log("QUIT");
	}
}
