using System.Collections.Generic;

public class AW2DMainRoomFactory: AW2DEntityFactory
{

    // MARK: - Lifecycle

    public AW2DMainRoomFactory() {
        assignedIds = new List<AW2DEntityID>{
            AW2DEntityID.mainroom_TV,
            AW2DEntityID.mainroom_bed,
            AW2DEntityID.mainroom_bin,
			AW2DEntityID.mainroom_key,
			AW2DEntityID.mainroom_door,
            AW2DEntityID.mainroom_desk,
            AW2DEntityID.mainroom_chair,
            AW2DEntityID.mainroom_window,
            AW2DEntityID.mainroom_shelf2,
            AW2DEntityID.mainroom_shelf1,
            AW2DEntityID.mainroom_guitar,
            AW2DEntityID.mainroom_deskLamp,
            AW2DEntityID.mainroom_floorLamp,
            AW2DEntityID.mainroom_wallClock,
            AW2DEntityID.mainroom_alarmClock
        };
    }

    // MARK: - Actions

    public override AW2DEntity createEntity(AW2DEntityID id) {
        //switch (id) {
        //    case .AW2DEntityID.mainroom_floorLamp:


                
        //}
        return null;
    }

}
