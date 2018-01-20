using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class TextTree : MonoBehaviour {
	[SerializeField] TextThing[] text;
	public int currentNumber = 0;
	
	public string GetString(){
		var t = text[currentNumber].text;
		currentNumber ++;
		return t;
	}
	
}

[System.Serializable]
public class TextThing{
	public string text;

	public UnityEvent OnStart, OnLeave;
	
	public TextTree nextTree;
	
	
}
