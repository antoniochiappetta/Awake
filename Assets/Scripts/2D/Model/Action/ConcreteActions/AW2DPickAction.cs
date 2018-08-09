public class AW2DPickAction : AW2DAction {

    // MARK: - Lifecycle

    AW2DPickAction() { }
	
    // MARK: - Actions

    public override void execute() {
		if (subject != null)
		{
			subject.actionsDelegate.moveTo(subject);
            subject.actionsDelegate.pick(subject);
        }
    }
}
