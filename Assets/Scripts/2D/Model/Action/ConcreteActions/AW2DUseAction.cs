public class AW2DUseAction : AW2DAction {

    // MARK: - Lifecycle

    AW2DUseAction(AW2DEntity subject) {
        this.subject = subject;
    }
	
    // MARK: - Actions

    public override void execute() {
        this.subject.actionsDelegate.moveTo(subject);
        this.subject.actionsDelegate.use(subject);
    }
}
