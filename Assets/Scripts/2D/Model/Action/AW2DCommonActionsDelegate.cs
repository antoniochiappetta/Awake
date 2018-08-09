public abstract class AW2DCommonActionsDelegate {

    // MARK: - Abstract methods

    abstract public void moveTo(AW2DEntity entity);
    abstract public void say(string text);
    abstract public void turnTowards(AW2DEntity entity);
    abstract public void pick(AW2DEntity entity);
    abstract public void use(AW2DEntity entity);
    abstract public void interact(AW2DEntity source, AW2DEntity destination);
	
}
