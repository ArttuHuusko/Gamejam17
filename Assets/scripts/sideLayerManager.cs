using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class sideLayerManager : MonoBehaviour {

	bool isMoving = false;
	float currentVelocity;
	public float startPos;
	public float currentPos;
	public float smoothZ;
	int nextPositionMinus = 1;
	public float animationSpeed = 1f;
	public float layerDistance = 3000f;
	public float nextPosition;

	void Start()
	{
		//nextPosition = transform.localPosition.z;
	}

	void Update () 
	{
		if (Input.mouseScrollDelta.y != 0f && isMoving == false)
		{
			isMoving = true;
			startPos = transform.localPosition.z;
			currentPos = 0f;
			nextPositionMinus = 1;
			if (Input.mouseScrollDelta.y != 0) 
				nextPosition = transform.localPosition.z + layerDistance;
			if (Input.mouseScrollDelta.y > 0)
				nextPositionMinus = -1;
		}

		if (isMoving) 
		{
			currentPos += Time.deltaTime * animationSpeed;
			//smoothZ = Mathf.SmoothDamp (startPos, nextPosition, ref currentVelocity, animationSpeed);
			smoothZ = smootherstep(startPos, nextPosition, currentPos);
			transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y, smoothZ * nextPosition * nextPositionMinus);
			if (smoothZ == 1f) 
			{
				isMoving = false;
			}
		}
	}

	float smootherstep(float edge0, float edge1, float x)
	{
		// Scale, and clamp x to 0..1 range
		x = Mathf.Clamp((x - edge0)/(edge1 - edge0), 0.0f, 1.0f);
		// Evaluate polynomial
		return x*x*x*(x*(x*6 - 15) + 10);
	}
}
