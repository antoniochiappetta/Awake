using System.Collections.Generic;

public class AW2DMainCharacter
{

    public static AW2DMainCharacter sharedInstance = new AW2DMainCharacter();

    // MARK: - Properties

    public List<AW2DEntityID> inventoryItems;

    // MARK: - Lifecycle

    private AW2DMainCharacter() {
        inventoryItems = new List<AW2DEntityID>();
    }
}
