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
		Debug.Log (startPos);
	}

	public void OnDrag(PointerEventData eventData)
	{
		// problem line that I can't get working... shit...
		Vector3 mouseVector = mainCamera.ScreenToWorldPoint ((Vector3)eventData.position + (Vector3.forward * eventData.pointerDrag.transform.parent.transform.position.z));

		transform.position = new Vector3 (mouseVector.x, mouseVector.y, mouseVector.z);
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		transform.position = new Vector3(startPos.x, startPos.y, transform.parent.position.z);
		GetComponent<CanvasGroup>().blocksRaycasts = true;
	}
}
