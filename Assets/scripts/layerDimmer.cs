using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class layerDimmer : MonoBehaviour 
{
	GameObject[] layerChildren;
	float layerDistanceCopy;

	void Start () 
	{
		layerDistanceCopy = transform.parent.gameObject.GetComponent<sideLayerManager> ().layerDistance;

		layerChildren = new GameObject[transform.childCount];
		for (int c = 0; c < layerChildren.Length; c++) 
			layerChildren [c] = transform.GetChild (c).gameObject;

		for (int c = 0; c < layerChildren.Length; c++) 
			Debug.Log (layerChildren[c]);
	}

	void Update () 
	{
		//for (int c = 0; c < layerChildren.Length; c++) 
		//{
			// v = 3000 -> 0, v = -3000 -> 0, v= 0 -> 1
			//layerChildren[c].GetComponent<Image> ().color = new Color (1, 1, 1, 
		//}
	}
}
