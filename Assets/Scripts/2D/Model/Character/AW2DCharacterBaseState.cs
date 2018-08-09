public class AW2DCharacterBaseState
{
    // MARK: - Properties

    public AW2DEntityPosition position;
	public AW2DAction examineAction;
	public AW2DAction talkToAction;
	public AW2DAction interactWithAction;

    // MARK: - Lifecycle

    public AW2DCharacterBaseState(AW2DEntityPosition position, AW2DAction examineAction, AW2DAction talkToAction, AW2DAction interactWithAction) {
        this.position = position;
        this.examineAction = examineAction;
        this.talkToAction = talkToAction;
        this.interactWithAction = interactWithAction;
    }

}
