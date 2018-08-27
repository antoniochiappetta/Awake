using System.Collections.Generic;

﻿public abstract class AW2DAction {

    // MARK: - Properties

    public AW2DEntityComponent subject;
    public Dictionary<string, string> parameters;
    public int nextState;

    // MARK: - Abstract methods

    abstract public void execute();
	
}
