using System.Collections.Generic;

public class AW2DPickAction : AW2DAction {

    // MARK: - Lifecycle

    public AW2DPickAction() { }
	
    // MARK: - Actions

    public override void execute() {
		if (subject != null)
		{
			subject.actionsDelegate.moveTo(subject);
            subject.actionsDelegate.pick(subject);
            foreach (string key in parameters.Keys) {
                // Set value for key
            }
        }
    }
}
