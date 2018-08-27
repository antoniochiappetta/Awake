using System.Collections.Generic;

public class AW2DSayAction: AW2DAction {

    // MARK: - Properties

    public string textToSay;

    // MARK: - Lifecycle

    public AW2DSayAction(string textToSay) {
        this.textToSay = textToSay;
    }
	
    // MARK: - Actions

    public override void execute() {
		if (subject != null)
		{
			subject.actionsDelegate.say(textToSay);
            foreach(string key in parameters.Keys) {
                
            }
        }
    }
}
