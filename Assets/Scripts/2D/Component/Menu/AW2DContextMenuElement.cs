using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class AW2DContextMenuElement: MonoBehaviour
{

    // MARK: - Properties


    // MARK: - Events

    private void OnMouseOver()
    {
        transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
    }

    private void OnMouseExit()
	{
		transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }

}
