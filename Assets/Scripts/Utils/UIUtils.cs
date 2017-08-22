using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIUtils {

	public static void showCanvas(CanvasGroup canvas){
		canvas.alpha = 1;
		canvas.interactable = true;
	}

	public static void hideCanvas(CanvasGroup canvas){
		canvas.alpha = 0;
		canvas.interactable = false;
	}
	
}
