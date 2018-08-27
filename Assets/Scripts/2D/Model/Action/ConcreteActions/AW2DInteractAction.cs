using System.Collections.Generic;

public class AW2DInteractAction : AW2DAction
{
    // MARK: - Properties

    public AW2DEntityComponent interactionObject;
	public bool hasInteracted;

    // MARK: - Lifecycle

    public AW2DInteractAction() {
        this.interactionObject = null;
        this.hasInteracted = false;
    }

    public AW2DInteractAction(AW2DEntityComponent interactionObject) {
        this.interactionObject = interactionObject;
        this.hasInteracted = false;
    }
	
    // MARK: - Actions

    public override void execute() {
		if (subject != null)
		{
			subject.actionsDelegate.interact(subject, interactionObject);
            foreach(string key in parameters.Keys) {
                
            }
        }
    }
}
