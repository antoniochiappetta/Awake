public class AW2DItemBaseState
{
    // MARK: - Properties

    public AW2DEntityPosition position;
	public AW2DAction examineAction;
	public AW2DAction interactWithAction;
    public AW2DAction pickUpAction;
    public AW2DAction useOnAction;

    // MARK: - Lifecycle

    public AW2DItemBaseState(AW2DEntityPosition position, AW2DAction examineAction, AW2DAction interactWithAction, AW2DAction pickUpAction, AW2DAction useOnAction) {
        this.position = position;
        this.examineAction = examineAction;
        this.interactWithAction = interactWithAction;
        this.pickUpAction = pickUpAction;
        this.useOnAction = useOnAction;
    }

}
