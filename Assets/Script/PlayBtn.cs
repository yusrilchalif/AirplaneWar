﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBtn : MonoBehaviour {

	// public Texture2D cursorImage;

	// private int cursorWidth = 32;
	// private int cursorHeight = 32;

	// void Start(){
	// 	Screen.showCursor = false;
	// }

	public void OnClick(){
		Application.LoadLevel("SampleScene");
	}

	// void OnGui(){
	// 	GUI.DrawTexture(new Rect(Input.mousePosition.x, Screen.height - Input.mousePosition.y, cursorWidth, cursorHeight), cursorImage);
	// }
}
