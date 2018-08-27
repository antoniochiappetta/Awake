using System.Collections.Generic;

public class AW2DCharacter: AW2DEntityComponent
{
    // MARK: - Properties

    public Dictionary<int, AW2DCharacterBaseState> states;
    override public AW2DEntityPosition position {
        get {
            return states[currentState].position;
        }
    }

    // MARK: - Lifecycle

    public void Start()
    {
        this.states = new Dictionary<int, AW2DCharacterBaseState>();
    }

    // MARK: - Actions

    public void examine() {
        AW2DAction examineAction = states[currentState].examineAction;
        examineAction.subject = this;
        examineAction.execute();
    }

    public void talkTo() {
        AW2DAction talkToAction = states[currentState].talkToAction;
        talkToAction.subject = this;
        talkToAction.execute();
    }

    public void interactWith() {
        AW2DAction interactWithAction = states[currentState].interactWithAction;
        interactWithAction.subject = this;
        interactWithAction.execute();
    }
}
