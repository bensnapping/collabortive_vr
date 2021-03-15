using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySlides : MonoBehaviour
{
	
	SpriteRenderer spriteRenderer;
	
	public AudioSource speaker;
	
	[HideInInspector] public List<SlideOrder> slides = new List<SlideOrder>();
	
	void Start(){
		spriteRenderer = this.GetComponent<SpriteRenderer>();
		
		StartCoroutine(Sequence());
	}
	
    void ChangeSprite(int x){
		spriteRenderer.sprite = slides[x].slide;
	}
	
	IEnumerator Sequence(){
		
		for (int curSlide = 0; curSlide < slides.Count; curSlide++){
			
			ChangeSprite(curSlide);
			
			speaker.clip = slides[curSlide].attachedAudio;
			speaker.Play();
			
			yield return new WaitForSeconds(slides[curSlide].attachedAudio.length + 1);
			
		}
	}
}