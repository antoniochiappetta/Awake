using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class AW2DContextMenu: MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    // MARK: - Properties

    public Sprite examineSprite;
    public Sprite interactSprite;
    public Sprite pickSprite;
    public Sprite saySprite;
    public Sprite useSprite;
    public List<bool> actionsToUse;

    private AW2DContextMenuPhase phase = AW2DContextMenuPhase.resting;

    // Get the long press to make the menu appear
    private float holdTime = 0.5f;
    private GameObject actionManager;

    // MARK: - Events

    private void Start()
    {
        setupSubnodes();
    }

    private void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
	{
		if (phase == AW2DContextMenuPhase.resting)
		{
			Invoke("OnLongPress", holdTime);
			Debug.Log("Invoke on long press");
        }
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		if (phase == AW2DContextMenuPhase.resting)
		{
			CancelInvoke("OnLongPress");
			Debug.Log("Cancel on long press");
        }

		if (phase == AW2DContextMenuPhase.folded)
		{
			disableMenu();
		}
	}

    void OnLongPress()
    {
		enableMenu();
		Debug.Log("on long press");
    }

    public void setupSubnodes() {
        actionManager = new GameObject();
		actionManager.transform.parent = this.transform;
		actionManager.transform.localPosition = Vector3.zero;
		actionManager.transform.localScale = new Vector3(1.0f, 1.0f, 0);
        actionManager.name = "Action manager";
        Canvas objectCanvas = actionManager.AddComponent<Canvas>();
        objectCanvas.overrideSorting = true;
        objectCanvas.sortingOrder = 100;
        for (int i = 0; i < actionsToUse.Count; i++)
        {
            bool actionFlag = actionsToUse[i];
			if (actionFlag)
			{
				GameObject action = new GameObject();
                action.transform.parent = actionManager.transform;
                action.transform.localPosition = Vector3.zero;
                action.transform.localScale = new Vector3(0.015f, 0.015f, 0);
                AW2DContextMenuElement contextMenuComponent = action.AddComponent<AW2DContextMenuElement>();
                Image actionRenderer = action.AddComponent<Image>();
                actionRenderer.enabled = false;
                switch (i) {
                    case 0:
                        action.name = "Examine node";
                        actionRenderer.sprite = examineSprite;
                        break;
					case 1:
						action.name = "Interact node";
                        actionRenderer.sprite = interactSprite;
                        break;
					case 2:
						action.name = "Pick node";
                        actionRenderer.sprite = pickSprite;
                        break;
					case 3:
						action.name = "Say node";
                        actionRenderer.sprite = saySprite;
                        break;
					case 4:
						action.name = "Use node";
                        actionRenderer.sprite = useSprite;
                        break;
                }
			}
        }
    }

	public void enableMenu()
	{
		Debug.Log("enable menu");
        phase = AW2DContextMenuPhase.folding;
        for (int i = 0; i < actionManager.transform.childCount; i++) {
            Image actionRenderer = actionManager.transform.GetChild(i).GetComponent<Image>();
            actionRenderer.enabled = true;
            actionRenderer.transform.localPosition = new Vector3(getXPosition(i), getYPosition(i), 0);
        }
        phase = AW2DContextMenuPhase.folded;

    }

    public void disableMenu()
    {
        Debug.Log("disable menu");
        phase = AW2DContextMenuPhase.unfolding;
        for (int i = 0; i < actionManager.transform.childCount; i++) {
            Image actionRenderer = actionManager.transform.GetChild(i).GetComponent<Image>();
			actionRenderer.enabled = false;
            actionRenderer.transform.localPosition = Vector3.zero;
		}
        phase = AW2DContextMenuPhase.resting;
    }

	private float getXPosition(int index)
	{
        int numberOfActions = actionManager.transform.childCount;
        float distance = 1.5f;
        switch (numberOfActions%2)
        {
			case 0:
				return (index - numberOfActions / 2 + 0.5f) * distance;
            case 1:
                return (index - (numberOfActions - 1) / 2) * distance;
        }
        return 0;
    }

    private float getYPosition(int index)
    {
        int numberOfActions = actionManager.transform.childCount;
        float distance = 1.5f;
		switch (numberOfActions % 2)
		{
			case 0:
                return ((numberOfActions / 2 + 0.5f) * distance) - Mathf.Abs(index - numberOfActions / 2 + 0.5f) * distance;
			case 1:
                return (((numberOfActions - 1) / 2) * distance) - Mathf.Abs(index - (numberOfActions - 1) / 2) * distance;
        }
        return 0;
    }

}
