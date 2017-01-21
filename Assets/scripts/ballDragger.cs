using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class ballDragger : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler 
{
	Vector3 startPos;
	public Camera mainCamera;
	public Canvas mainCanvas;

	public void OnBeginDrag (PointerEventData eventData)
	{
		startPos = transform.position;
		GetComponent<CanvasGroup>().blocksRaycasts = false;
	}

	public void OnDrag(PointerEventData eventData)
	{
		transform.position = mainCamera.ScreenToWorldPoint ((Vector3)eventData.position + (Vector3.forward * mainCanvas.planeDistance));
		Debug.Log (mainCamera.ScreenToWorldPoint (eventData.position));
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		transform.position = startPos;
		GetComponent<CanvasGroup>().blocksRaycasts = true;
	}
}
