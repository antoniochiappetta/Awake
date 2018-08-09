public class AW2DInteractAction : AW2DAction
{
    // MARK: - Properties

    public AW2DEntity interactionObject;
	public bool hasInteracted;

    // MARK: - Lifecycle

    AW2DInteractAction(AW2DEntity interactionObject) {
        this.interactionObject = interactionObject;
        this.hasInteracted = false;
    }
	
    // MARK: - Actions

    public override void execute() {
		if (subject != null)
		{
			subject.actionsDelegate.interact(subject, interactionObject);
        }
    }
}
