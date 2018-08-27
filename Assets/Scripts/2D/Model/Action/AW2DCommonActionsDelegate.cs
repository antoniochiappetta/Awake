public abstract class AW2DCommonActionsDelegate {

    // MARK: - Abstract methods

    abstract public void moveTo(AW2DEntityComponent entity);
    abstract public void say(string text);
    abstract public void turnTowards(AW2DEntityComponent entity);
    abstract public void pick(AW2DEntityComponent entity);
    abstract public void use(AW2DEntityComponent entity);
    abstract public void interact(AW2DEntityComponent source, AW2DEntityComponent destination);
	
}
