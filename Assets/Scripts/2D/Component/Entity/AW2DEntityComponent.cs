using UnityEngine;
using System.Collections;

public abstract class AW2DEntityComponent: MonoBehaviour
{

    // MARK: - Properties

    public AW2DEntityID id;
    protected int currentState;
    public abstract AW2DEntityPosition position {
        get;
    }
    public AW2DCommonActionsDelegate actionsDelegate;

    // MARK: - Lifecycle

    private void Start()
    {
        currentState = 0;
    }

    // MARK: - Actions

    int getState() {
        return this.currentState;
    }

}
