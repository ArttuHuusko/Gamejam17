using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class ballDragger : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler 
{
	Vector3 startPos;
	public Camera mainCamera;

	public void OnBeginDrag (PointerEventData eventData)
	{
		startPos = transform.position;
		GetComponent<CanvasGroup>().blocksRaycasts = false;
	}

	public void OnDrag(PointerEventData eventData)
	{
		transform.position = mainCamera.ScreenToWorldPoint (eventData.position) + Vector3.forward;
		GetComponent<Image>().color = Color.white;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		transform.position = startPos;
		GetComponent<CanvasGroup>().blocksRaycasts = true;
	}
}
