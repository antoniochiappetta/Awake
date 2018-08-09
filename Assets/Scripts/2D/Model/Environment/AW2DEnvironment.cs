using System.Collections.Generic;

public class AW2DEnvironment
{

    // MARK: - Properties

    public AW2DEnvironmentID id;
    public string name;
    public List<AW2DPassage> passages;

    // MARK: - Lifecycle

    public AW2DEnvironment(AW2DEnvironmentID id, string name) {
        this.id = id;
        this.name = name;
        this.passages = new List<AW2DPassage>();
    }

}
