using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class TextTree : MonoBehaviour {
	[SerializeField] public TextThing[] text;

	
	public TextTree nextTree;

	
}

[System.Serializable]
public class TextThing{
	public string text;

	public UnityEvent OnStart, OnLeave;
	
	public Button[] Buttons;
	public TextType type = TextType.TextOnly;
	
	public void ShowButtons(){
		foreach(var b in Buttons){
			b.gameObject.SetActive(true);
		}
	}
}
public enum TextType{
	TextOnly = 0,
	Button = 1,

	OnCustomEvent = 3
	
}