using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class sideCannonDrag : MonoBehaviour, IDropHandler
{
	public void OnDrop(PointerEventData eventData)
	{
		GetComponent<Image> ().color = Random.ColorHSV ();
	}
}
