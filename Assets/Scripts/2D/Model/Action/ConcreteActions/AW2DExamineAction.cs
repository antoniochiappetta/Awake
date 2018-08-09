public class AW2DExamineAction: AW2DAction {

    // MARK: - Properties

    public string descriptionText;

    // MARK: - Lifecycle

    AW2DExamineAction(string descriptionText) {
        this.descriptionText = descriptionText;
    }
	
    // MARK: - Actions

    public override void execute() {
		if (subject != null)
		{
			subject.actionsDelegate.turnTowards(subject);
			subject.actionsDelegate.say(descriptionText);
        }
    }
}
