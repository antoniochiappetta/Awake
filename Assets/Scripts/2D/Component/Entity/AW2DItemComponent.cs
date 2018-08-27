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
        currentState = 0; // NO CONTROLLA

        switch (this.id) {

			// Add all the states for each object in the scenes


			// Main character room
			case AW2DEntityID.mainroom_alarmClock:
				// Aggiugi all'inventario con pick
				AW2DPickAction clockPickAction = new AW2DPickAction();
                clockPickAction.subject = this;
                clockPickAction.nextState = 1;
                AW2DItemBaseState clockPickState = new AW2DItemBaseState("pickup", clockPickAction);
                states.Add(0, clockPickState);
                break;
			case AW2DEntityID.mainroom_desk:
                // Interact dallo stato 0 fa aprire la scrivania e la fa transitare in stato 1
                AW2DInteractAction deskInteractAction = new AW2DInteractAction();
                deskInteractAction.subject = this;



				// Aggiungi all'inventario key e set keyPicked to true con pick se lo stato è 1, quindi stato 2
				AW2DPickAction keyPickAction = new AW2DPickAction();
                AW2DItemComponent key = new AW2DItemComponent();
                key.id = AW2DEntityID.mainroom_key;
                keyPickAction.subject = key;
                Dictionary<string, string> keyPickParameters = new Dictionary<string, string>();
                keyPickParameters.Add("keyPicked", "true");
                keyPickAction.parameters = keyPickParameters;
                keyPickAction.nextState = 2;
                AW2DItemBaseState keyPickState = new AW2DItemBaseState("pickup", keyPickAction);
                states.Add(1, keyPickState);
                // Se la chiave è già stata presa si transita direttamente allo stato 2
                break;
            case AW2DEntityID.mainroom_key:
                // Use on con la door set locked to false e apri porta
                break;
            case AW2DEntityID.mainroom_door:
                AW2DSayAction sayDoorAction = new AW2DSayAction("The door is closed");
                sayDoorAction.subject = this;
                sayDoorAction.parameters = new Dictionary<string, string>();
                sayDoorAction.nextState = 0;
                AW2DItemBaseState sayDoorState = new AW2DItemBaseState("examine", sayDoorAction);
                states.Add(0, sayDoorState);
                //AW2DUseAction openDoorAction = new AW2DUseAction();
                AW2DInteractAction interactDoorAction = new AW2DInteractAction();
                interactDoorAction.subject = this;
                interactDoorAction.sceneToMove = "_Scenes/2DWorld/UpstairsCorridor";
                interactDoorAction.parameters = new Dictionary<string, string>();
                interactDoorAction.nextState = 2;
                AW2DItemBaseState goToCorridorState = new AW2DItemBaseState("interact", interactDoorAction);
                states.Add(2, goToCorridorState);
                break;
            case AW2DEntityID.mainroom_bed:
                AW2DSayAction sayBedAction = new AW2DSayAction("I should explore the house before going to bed");
                sayBedAction.subject = this;
                sayBedAction.parameters = new Dictionary<string, string>();
                sayBedAction.nextState = 0;
                AW2DItemBaseState sayBedState = new AW2DItemBaseState("examine", sayBedAction);
                states.Add(0, sayBedState);
                AW2DInteractAction goToBedAction = new AW2DInteractAction();
                goToBedAction.subject = this;
                goToBedAction.sceneToMove = "_Scenes/3DWorld";
                goToBedAction.parameters = new Dictionary<string, string>();
                goToBedAction.nextState = 2;
                AW2DItemBaseState goToBedState = new AW2DItemBaseState("interact", goToBedAction);
                states.Add(1, goToBedState);
                break;

            default:
                break;
        }
    }

	// MARK: - Actions

	void examine()
	{
		Debug.Log("Examine method called");
        AW2DAction examineAction = states[currentState].examineAction;
        //examineAction.subject = this;
        examineAction.execute();
        currentState = examineAction.nextState;
    }

	void interactWith()
	{
		Debug.Log("Interact with method called");
        AW2DAction interactWithAction = states[currentState].interactWithAction;
        //interactWithAction.subject = this;
        interactWithAction.execute();
        currentState = interactWithAction.nextState;
    }

	void pickUp()
	{
		Debug.Log("Pick up method called");
        AW2DAction pickUpAction = states[currentState].pickUpAction;
        //pickUpAction.subject = this;
        pickUpAction.execute();
        currentState = pickUpAction.nextState;
    }

    bool useOn(AW2DEntityComponent
               entity = null)
	{
		Debug.Log("Use on method called");
        AW2DAction useOnAction = states[currentState].useOnAction;
        //useOnAction.subject = this;
        useOnAction.execute();
        currentState = useOnAction.nextState;

        AW2DInteractAction useInteraction = useOnAction as AW2DInteractAction;
        if (useInteraction != null) {
            //useInteraction.interactionObject = entity;
            useInteraction.execute();
            //return useInteraction.hasInteracted;
        }

        useOnAction.execute();
        return false;
    }

}
