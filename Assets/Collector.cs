using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Collector : MonoBehaviour {
	public Text text;
	public int currentNode =0;
	public TextTree current;
	static Collector _main;
	
	public float multiplier = 60;
	float timer = 0;
	bool done = false;
	[SerializeField] Image arrow;
	static Collector Main { get{
		if(_main == null)
		_main = FindObjectOfType<Collector>();
		return _main;
	}}
	
	void Awake()
	{
		arrow.gameObject.SetActive(false);
	}
	void Update()
	{
		
	
		if(current != null){
			if(!done){
				if(timer >= 1){
					done = true;
					switch(current.text[currentNode].type){
						case TextType.TextOnly:
						arrow.gameObject.SetActive(true);
						break;
					}
					
				}
				else{
					timer += ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.KeypadEnter))? 1:0) ;
					timer += Time.deltaTime/current.text[currentNode].text.Length* 10;
				}
				text.text = Lerp(current.text[currentNode].text,timer);
				if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.KeypadEnter)){
					return;
				}
			}
			else{
			switch(current.text[currentNode].type){
						case TextType.TextOnly:
							if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.KeypadEnter)){
								currentNode ++;
								timer = 0;
								text.text = "";
								arrow.gameObject.SetActive(false);
								done = false;
							}
							break;
						case TextType.Button:
							current.text[currentNode].ShowButtons();
							break;
					}
			}
		}
		
		
	}

	private const string TWITTER_ADDRESS = "http://twitter.com/intent/tweet";
	private const string TWEET_LANGUAGE = "en";

	public void Next(){
		Application.OpenURL("https://twitter.com/3kTwBot");
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
		
		return tex.Substring(0,newI);
	}
}
