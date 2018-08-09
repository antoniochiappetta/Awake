public class AW2DPassage
{

    // MARK: - Properties

    public AW2DPassageID id;
    public AW2DEnvironmentID envA;
    public AW2DEnvironmentID envB;
    public AW2DAction passageAction;

    // MARK: - Lifecycle

    public AW2DPassage(AW2DPassageID id, AW2DEnvironmentID envA, AW2DEnvironmentID envB, AW2DAction passageAction = null) {
        this.id = id;
        this.envA = envA;
        this.envB = envB;
        this.passageAction = passageAction;
    }

    // MARK: - Actions

    AW2DEnvironmentID getDestinationEnvironmentFrom(AW2DEnvironmentID environment) {
        if (environment == envB) {
            return envA;
        }
        return envB;
    }

}
