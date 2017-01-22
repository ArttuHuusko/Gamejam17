using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class sideLayerManager : MonoBehaviour {

	bool isMoving = false;
	float currentVelocity;
	public float startPos;
	public float currentPos;
	public float smoothZ;
	public int nextPositionMinus = 1;
	public float animationSpeed = 1f;
	public float layerDistance = 3000f;
	public float nextPosition;

	void Start()
	{
		
	}

	void Update () 
	{
		if (Input.mouseScrollDelta.y != 0f && isMoving == false)
		{
			isMoving = true;
			startPos = transform.localPosition.z;
			currentPos = 0f;
			nextPositionMinus = 1;
			smoothZ = 0f;
			if (Input.mouseScrollDelta.y < 0) 
			{
				if (transform.localPosition.z == layerDistance)
					isMoving = false;
				nextPosition = layerDistance;
			}
			if (Input.mouseScrollDelta.y > 0) 
			{
				if (transform.localPosition.z == -layerDistance)
					isMoving = false;
				nextPosition = -layerDistance;
			}
		}

		if (isMoving) 
		{
			currentPos += Time.deltaTime * animationSpeed;
			smoothZ = smootherstep(0f, 1f, currentPos);
			transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y, nextPosition * smoothZ + startPos);
			if (smoothZ == 1f)
				isMoving = false;
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
