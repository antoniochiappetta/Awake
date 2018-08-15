using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class AW2DContextMenuElement: MonoBehaviour
{

	bool isOver = false;

    // MARK: - Events

 //   private void Update()
 //   {
 //       if (IsPointerOverGameObject())
	//	{
	//		if (!isOver)
	//		{
	//			isOver = true;
	//			transform.localScale = transform.localScale * 1.2f;
 //           }
	//	}
	//	else
	//	{
 //           if (isOver) {
	//			isOver = false;
	//			transform.localScale = transform.localScale / 1.2f;
 //           }
 //       }
 //   }

	//public bool IsPointerOverGameObject()
	//{
 //       //check mouse
 //       if (EventSystem.current.IsPointerOverGameObject())
 //       {
 //           return true;
 //       }
	//	//check touch
	//	if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
	//	{
	//		if (EventSystem.current.IsPointerOverGameObject(Input.touches[0].fingerId))
	//			return true;
	//	}

	//	return false;
	//}

}
