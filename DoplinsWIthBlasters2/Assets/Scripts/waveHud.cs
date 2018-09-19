using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class waveHud : MonoBehaviour {

	[SerializeField]
	private float WavetimeNeeded = 30;

	[SerializeField]
	private float TimeUntilNextWave = 5;

	private float smootness = 30;

	private bool _arrived = false;

	private bool secondWaveAndOn = false;
	float multiplier = 1;

	[SerializeField]
	private GameObject Textpopup;

	Image image;

	// Use this for initialization
	void Start () {
		image = this.GetComponent<Image> ();
		//StartCoroutine (popUp());
		//image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
	}

	void FixedUpdate()
	{
		
		
		if (this.transform.localPosition.x >= 500f && !_arrived) {
			
			//this.transform.Translate (-500, 0, 0);
			_arrived = true;
			StartCoroutine (popUp ());
			StartCoroutine (move ());
		} 
		else if(this.transform.localPosition.x <= 500f && !_arrived) {
			this.transform.position += new Vector3 (500 / WavetimeNeeded * Time.deltaTime, 0, 0);
		}
	}

	private IEnumerator move()
	{
		while (image.color.a > 0.1)
		{
			
			image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a- 0.1f);
			yield return new WaitForSeconds (TimeUntilNextWave/(smootness));

		}
		if (image.color.a > 0)
		{
			image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
		}

		this.transform.localPosition = new Vector3 (0, 0, 0);
		yield return new WaitForSeconds (TimeUntilNextWave/(smootness/10));
		while (image.color.a < 1) 
		{
			image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a + 0.1f);
			yield return new WaitForSeconds (TimeUntilNextWave/(smootness));
		}
			
		_arrived = false;
	}

	private IEnumerator popUp()
	{
		
		if (secondWaveAndOn)
		{
			multiplier = 0;
		}
		yield return new WaitForSeconds (TimeUntilNextWave + (WavetimeNeeded *multiplier) - 10);
		Textpopup.SetActive (true);
		secondWaveAndOn = true;
		yield return new WaitForSeconds (3);
		Textpopup.SetActive (false);
	}
}
