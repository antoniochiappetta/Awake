using UnityEngine;
using System.Collections;

public abstract class AW2DEntity
{

    // MARK: - Properties

    public AW2DEntityID id;
    public string name;
    public int currentState;
    public abstract AW2DEntityPosition position {
        get;
    }
    public AW2DCommonActionsDelegate actionsDelegate;

    // MARK: - Lifecycle

    public AW2DEntity(AW2DEntityID id, string name) {
        this.id = id;
        this.name = name;
    }

}
