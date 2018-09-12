class BevNodeTerminal:BevNode {
    protected virtual void _DoEnter(BevNodeInputParam input) {}
    protected virtual void _DoExit(BevNodeInputParam input) {}
    protected virtual BevRunningState _DoExecute(BevNodeInputParam input, BevNodeOutputParam output) {
        return BevRunningState.TRUE; 
    }
}