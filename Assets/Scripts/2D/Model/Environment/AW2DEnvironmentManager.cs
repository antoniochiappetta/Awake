using System.Collections.Generic;

public class AW2DEnvironmentManager
{

    public static AW2DEnvironmentManager sharedInstance = new AW2DEnvironmentManager();

    // MARK: - Properties

    public AW2DEnvironment mainRoom {
        get {
            AW2DEnvironment env = new AW2DEnvironment(AW2DEnvironmentID.mainCharBedroom, "Laz' bedroom");
            AW2DPassage mainRoomDoor = new AW2DPassage(AW2DPassageID.mainCharBedroomDoor, AW2DEnvironmentID.mainCharBedroom, AW2DEnvironmentID.upstairsCorridor);
            env.passages.Add(mainRoomDoor);
            return env;
        }
    }

    public AW2DEnvironment upstairsCorridor {
        get {
            AW2DEnvironment env = new AW2DEnvironment(AW2DEnvironmentID.upstairsCorridor, "Upstairs corridor");
			AW2DPassage mainRoomDoor = new AW2DPassage(AW2DPassageID.mainCharBedroomDoor, AW2DEnvironmentID.mainCharBedroom, AW2DEnvironmentID.upstairsCorridor);
			AW2DPassage bathroom1Door = new AW2DPassage(AW2DPassageID.upstairsBathroomDoor, AW2DEnvironmentID.upstairsBathroom, AW2DEnvironmentID.upstairsCorridor);
			AW2DPassage parentsRoomDoor = new AW2DPassage(AW2DPassageID.parentsBedroomDoor, AW2DEnvironmentID.parentsBedroom, AW2DEnvironmentID.upstairsCorridor);
            AW2DPassage stairs = new AW2DPassage(AW2DPassageID.homeStairs, AW2DEnvironmentID.upstairsCorridor, AW2DEnvironmentID.downstairsCorridor);
			env.passages.Add(mainRoomDoor);
            env.passages.Add(bathroom1Door);
            env.passages.Add(parentsRoomDoor);
            env.passages.Add(stairs);
            return env;
        }
    }

    public AW2DEnvironment parentsRoom {
        get {
            AW2DEnvironment env = new AW2DEnvironment(AW2DEnvironmentID.parentsBedroom, "Parents' bedroom");
            AW2DPassage parentsRoomDoor = new AW2DPassage(AW2DPassageID.parentsBedroomDoor, AW2DEnvironmentID.parentsBedroom, AW2DEnvironmentID.upstairsCorridor);
            env.passages.Add(parentsRoomDoor);
            return env;
        }
    }

    public AW2DEnvironment upstairsBathroom {
        get {
            AW2DEnvironment env = new AW2DEnvironment(AW2DEnvironmentID.upstairsBathroom, "Upstairs bathroom");
            AW2DPassage bathroomDoor = new AW2DPassage(AW2DPassageID.upstairsBathroomDoor, AW2DEnvironmentID.upstairsBathroom, AW2DEnvironmentID.upstairsCorridor);
            env.passages.Add(bathroomDoor);
            return env;
        }
    }

    public AW2DEnvironment downstairsCorridor {
        get {
            AW2DEnvironment env = new AW2DEnvironment(AW2DEnvironmentID.downstairsBathroom, "Downstairs corridor");
            AW2DPassage bathroomDoor = new AW2DPassage(AW2DPassageID.downstairsBathroomDoor, AW2DEnvironmentID.downstairsCorridor, AW2DEnvironmentID.downstairsBathroom);
            env.passages.Add(bathroomDoor);
            return env;
        }
    }

    public AW2DEnvironment downstairsBathroom {
        get {
            AW2DEnvironment env = new AW2DEnvironment(AW2DEnvironmentID.downstairsBathroom, "Downstairs bathroom");
            AW2DPassage bathroomDoor = new AW2DPassage(AW2DPassageID.downstairsBathroomDoor, AW2DEnvironmentID.downstairsCorridor, AW2DEnvironmentID.downstairsBathroom);
            env.passages.Add(bathroomDoor);
            return env;
        }
    }

    // MARK: - Lifecycle

    private AW2DEnvironmentManager() { }

}
