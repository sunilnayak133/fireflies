using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firefly : MonoBehaviour {

	[SerializeField]
	private float speed;
	[SerializeField]
	private float time;

	[SerializeField]
	private Vector3 startPos;
	[SerializeField]
	private float timeLimit;

	[SerializeField]
	private float yAmp;
	[SerializeField]
	private float xAmp;

	private float curXAmp;
	private float curYAmp;

	[SerializeField]
	private bool oppositeLight;
	[SerializeField]
	private float lerpTime;

	[SerializeField]
	private float xOscSpeed;
	[SerializeField]
	private float yOscSpeed;

	private bool oscStarted = false;

	// Use this for initialization
	void Start () {
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;

		float x = startPos.x, y = startPos.y, z;
		z = startPos.z + time * speed;
		if (time > timeLimit) 
		{
			if (!oscStarted) 
			{
				float t = time - timeLimit;
				t /= lerpTime;

				if (t > 1)
					oscStarted = true;
				else 
				{
					curXAmp = Mathf.Lerp (0, xAmp, t);
					curYAmp = Mathf.Lerp (0, yAmp, t);
				}
			}

			float factor = (oppositeLight) ? Mathf.Deg2Rad * 90f : 0f;
			x = Mathf.Sin (factor + time * xOscSpeed) * curXAmp + startPos.x;
			y = Mathf.Cos (factor + time * yOscSpeed) * curYAmp + startPos.y;

		}

		transform.position = new Vector3 (x, y, z);
	}
}
