using UnityEngine;

public class AW2DEntityPosition
{

    // MARK: - Properties

    public bool isInInventory;
    public string scene;
    public Vector2 point;


    // MARK: - Lifecycle

    public AW2DEntityPosition(bool isInInventory, string scene, Vector2 point) {
        this.isInInventory = isInInventory;
        this.scene = scene;
        this.point = point;
    }

}
