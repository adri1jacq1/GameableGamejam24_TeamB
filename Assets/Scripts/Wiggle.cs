using System.Collections.Generic;
using UnityEngine;

public class WigggleV4 : MonoBehaviour {

	public float speed = 400f;
	public int lowTime = 20;
	public int highTime = 150;
	public float target;
	public float added;
	float current;
	public bool Direction;
	public bool occuredOnce;

	// Use this for initialization
	void Start()
	{
		occuredOnce = false;
		Debug.Log ("Start" + occuredOnce);
		added = (Random.Range (highTime, lowTime));
		target = Time.frameCount + added;
	}

	void Update () 	
	{
		//Debug.Log (current);
		current = Time.frameCount;

		if (Direction == true) 
		{ //used to go right

			Debug.Log ("left");

			transform.Rotate (Vector3.forward * speed * Time.deltaTime);
			if (occuredOnce == false) 
			{
				Debug.Log ("Once False DT");
				added = (Random.Range (highTime, lowTime));
				target = Time.frameCount + added;
				occuredOnce = true;
			}

			if (target == Time.frameCount) 
			{
				Debug.Log ("target = frames DT");
				Direction = false;
				occuredOnce = false;
			}


		}

		if (Direction == false) 
		{ //used to go left

			Debug.Log ("Right");
			    
			transform.Rotate (Vector3.back * speed * Time.deltaTime);
			if (occuredOnce == false) 
			{
				Debug.Log ("Once False DF");
				added = (Random.Range (highTime, lowTime));
				target = Time.frameCount + added;
				occuredOnce = true;
			}

			if (target == Time.frameCount) 
			{
				Debug.Log ("target = frames DF");
				Direction = true;
				occuredOnce = false;
			}
		}
	}
}