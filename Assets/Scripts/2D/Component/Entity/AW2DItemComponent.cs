using System.Collections.Generic;
using UnityEngine;

public class AW2DItemComponent : AW2DEntityComponent
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

    private void Start()
	{
		states = new Dictionary<int, AW2DItemBaseState>();
    }

	// MARK: - Actions

	void examine()
	{
		Debug.Log("Examine method called");
        AW2DAction examineAction = states[currentState].examineAction;
        //examineAction.subject = this;
        examineAction.execute();
    }

	void interactWith()
	{
		Debug.Log("Interact with method called");
        AW2DAction interactWithAction = states[currentState].interactWithAction;
        //interactWithAction.subject = this;
        interactWithAction.execute();
    }

	void pickUp()
	{
		Debug.Log("Pick up method called");
        AW2DAction pickUpAction = states[currentState].pickUpAction;
        //pickUpAction.subject = this;
        pickUpAction.execute();
    }

	bool useOn(AW2DEntity entity = null)
	{
		Debug.Log("Use on method called");
        AW2DAction useOnAction = states[currentState].useOnAction;
        //useOnAction.subject = this;
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
