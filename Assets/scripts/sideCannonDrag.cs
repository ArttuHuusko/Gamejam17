using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class sideCannonDrag : MonoBehaviour, IDropHandler
{
	public Sprite loadedCannon;
	public Sprite unloadedCannon;

	public void OnDrop(PointerEventData eventData)
	{
		GetComponent<Image> ().sprite = loadedCannon;
	}
}
