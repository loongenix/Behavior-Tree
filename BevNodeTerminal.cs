class BevNodeTerminal : BevNode {

    private bool _needExit;
    private ETerminalNodeStaus _states;
    protected virtual void _DoEnter (BevNodeInputParam input) { }
    protected virtual void _DoExit (BevNodeInputParam input) { }
    protected virtual EBevRunningState _DoExecute (BevNodeInputParam input, BevNodeOutputParam output) {
        return EBevRunningState.Finish;
    }
    protected override void _DoTransition (BevNodeInputParam input) { 
        if(_needExit){
            _DoExit(input);
        }
        SetActiveNode(null);

    }

    protected override EBevRunningState _DoTick (BevNodeInputParam inputParam, BevNodeOutputParam outputParam) {
        return EBevRunningState.Finish;
    }
}