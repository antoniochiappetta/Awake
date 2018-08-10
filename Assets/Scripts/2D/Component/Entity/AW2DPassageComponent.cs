using UnityEngine;

public class AW2DPassageComponent: MonoBehaviour
{

    // MARK: - Properties

    public AW2DPassageID id;
    public AW2DEnvironmentID envA;
    public AW2DEnvironmentID envB;
    public AW2DAction passageAction;

    // MARK: - Lifecycle

    private void Start()
    {
        
    }

    // MARK: - Actions

    AW2DEnvironmentID getDestinationEnvironmentFrom(AW2DEnvironmentID environment) {
        if (environment == envB) {
            return envA;
        }
        return envB;
    }

}
