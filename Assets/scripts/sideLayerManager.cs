using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class sideLayerManager : MonoBehaviour {

	bool isMoving = false;
	float currentVelocity;
	public float startPos;
	public float currentPos;
	public float smoothZ;
	public float animationSpeed = 1f;
	public float layerDistance = 3000f;
	public float nextPosition;
	public float maxAlpha = 70f;

	public Image botLayerShadow;
	public Image topLayerShadow;

	void Start()
	{
		maxAlpha = maxAlpha / 255;
	}

	void Update () 
	{
		if (Input.mouseScrollDelta.y != 0f && isMoving == false)
		{
			isMoving = true;
			startPos = transform.localPosition.z;
			currentPos = 0f;
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
			if (nextPosition + startPos < 0) 
			{
				botLayerShadow.color = new Color (0, 0, 0, (1 - smoothZ) * maxAlpha);
			}
			if (nextPosition + startPos > 0) 
			{
				topLayerShadow.color = new Color (0, 0, 0, smoothZ * maxAlpha);
			}
			if (nextPosition + startPos == 0) 
			{
				if (topLayerShadow.color == Color.clear)
					botLayerShadow.color = new Color (0, 0, 0, smoothZ * maxAlpha);
				if (topLayerShadow.color != Color.clear)
					topLayerShadow.color = new Color (0, 0, 0, (1 - smoothZ) * maxAlpha);
			}
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
