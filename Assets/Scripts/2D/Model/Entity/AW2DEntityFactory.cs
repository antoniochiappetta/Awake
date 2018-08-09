using System.Collections.Generic;

public abstract class AW2DEntityFactory
{
    // MARK: - Properties

    public List<AW2DEntityID> assignedIds;

    // MARK: - Actions

    public abstract AW2DEntity createEntity(AW2DEntityID id);

}
