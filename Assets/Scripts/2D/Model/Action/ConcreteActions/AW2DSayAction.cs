public class AW2DSayAction: AW2DAction {

    // MARK: - Properties

    public string textToSay;

    // MARK: - Lifecycle

    AW2DSayAction(string textToSay) {
        this.textToSay = textToSay;
    }
	
    // MARK: - Actions

    public override void execute() {
		if (subject != null)
		{
			subject.actionsDelegate.say(textToSay);
        }
    }
}
