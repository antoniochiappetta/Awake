//using System.Collections.Generic;

//public class AW2DItemManager
//{

//    public static AW2DItemManager sharedInstance = new AW2DItemManager();

//    // MARK: - Properties

//    public List<AW2DEntityID> assignedIds;
//    public Dictionary<AW2DEntityID, AW2DItem> allocatedItems;
//    public Dictionary<AW2DEntityID, AW2DEntityFactory> idToFactoryDict;

//    // MARK: - Actions

//    void addFactory(AW2DEntityFactory factory) {
//        factory.assignedIds.ForEach(delegate(AW2DEntityID id){
//            this.idToFactoryDict[id] = factory;
//        });
//    }

//    AW2DItem getItem(AW2DEntityID id) {
//        if (allocatedItems.ContainsKey(id)) {
//            return allocatedItems[id];
//        }
//        AW2DItem item = createEntity(id) as AW2DItem;
//        allocatedItems[id] = item;
//        return item;
//    }

//    AW2DEntity createEntity(AW2DEntityID id) {
//        if (idToFactoryDict.ContainsKey(id)) {
//            return idToFactoryDict[id].createEntity(id);
//        }
//        return null;
//    }


//    // MARK: - Lifecycle

//    private AW2DItemManager() {
//        assignedIds = new List<AW2DEntityID>();
//        allocatedItems = new Dictionary<AW2DEntityID, AW2DItem>();
//        idToFactoryDict = new Dictionary<AW2DEntityID, AW2DEntityFactory>();
//    }

//}
