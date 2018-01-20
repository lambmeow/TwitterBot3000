using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Collector : MonoBehaviour {
	public Text text;
	public int currentNode =0;
	public TextTree current;
	static Collector _main;
	public string test;
	[Range(0,1)]
	public float  alsotest;
	public float multiplier = 60;
	float timer = 0;
	bool done = false;

	static Collector Main { get{
		if(_main == null)
		_main = FindObjectOfType<Collector>();
		return _main;
	}}
	
	void Update()
	{
		
		if(!done){
				if(timer >= 1)
					done = true;
				else
					timer += Time.deltaTime;
				text.text = Lerp(test,timer);
			}
		if(current != null){
			
		}
		if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0)){
			
		}
	}
	void Next(){

	}
	public static void ChangeTextTree(TextTree tree){
		Main.currentNode = 0;
		Main.current = tree;
		
	}
	string Lerp(string tex, float t){
		if(t == 0)
			return "";
		if(t >= 1)
			t = 1;
		var length = tex.Length;
		float newL = length * t;
		var newI = (int)newL;
		print(newI);
		return tex.Substring(0,newI);
	}
}
