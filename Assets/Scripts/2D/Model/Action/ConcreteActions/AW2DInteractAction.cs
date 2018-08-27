using System.Collections.Generic;
using UnityEngine;

public class AW2DInteractAction : AW2DAction
{
    // MARK: - Properties

    public string sceneToMove;
    public Sprite spriteToChange;
	
    // MARK: - Actions

    public override void execute() {
		if (subject != null)
		{
			//subject.actionsDelegate.interact(subject, interactionObject);
            foreach(string key in parameters.Keys) {

			}
			if (sceneToMove != null)
			{
				LevelManager levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
                levelManager.LoadLevel(sceneToMove);
            }
        }
    }
}
