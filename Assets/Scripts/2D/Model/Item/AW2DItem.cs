using System.Collections.Generic;

public class AW2DItem: AW2DEntity
{
    // MARK: - Properties

    // action menu
    public Dictionary<int, AW2DItemBaseState> states;
    override public AW2DEntityPosition position {
        get {
            return states[currentState].position;
        }
    }

    // MARK: - Lifecycle

    public AW2DItem(AW2DEntityID id, string name): base(id, name) {
        states = new Dictionary<int, AW2DItemBaseState>();
    }

    // MARK: - Actions

    void examine() {
        AW2DAction examineAction = states[currentState].examineAction;
        examineAction.subject = this;
        examineAction.execute();
    }

    void interactWith() {
        AW2DAction interactWithAction = states[currentState].interactWithAction;
        interactWithAction.subject = this;
        interactWithAction.execute();
    }

    void pickUp() {
        AW2DAction pickUpAction = states[currentState].pickUpAction;
        pickUpAction.subject = this;
        pickUpAction.execute();
    }

    bool useOn(AW2DEntity entity = null) {
        AW2DAction useOnAction = states[currentState].useOnAction;
        useOnAction.subject = this;
        useOnAction.execute();

        AW2DInteractAction useInteraction = useOnAction as AW2DInteractAction;
        if (useInteraction != null) {
            useInteraction.interactionObject = entity;
            useInteraction.execute();
            return useInteraction.hasInteracted;
        }

        useOnAction.execute();
        return false;
    }

}
