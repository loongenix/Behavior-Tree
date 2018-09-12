using System.Collections.Generic; 

abstract class BevNode {
    protected List < BevNode > childNodeList; 
    protected BevNode parentNode {get; set; }
    protected BevNode LastActiveNode;
    protected BevNode ActiveNode;
    /// <summary>
    /// 外在在前提
    /// </summary>
    /// <param name="input">输入</param>
    protected BevNodePrecondition NodePrecondition; 
    ///<summary>
    ///判断节点是否可以被执行
    ///</summary>

    public bool Evaluate (BevNodeInputParam input) {
        return (NodePrecondition == null || NodePrecondition.ExternalCondition (input)) && _DoEvaluate (input); 
    }

    public void Transition (BevNodeInputParam input) {
        _DoTransition (input); 
    }
    public  EBevRunningState Tick (BevNodeInputParam inputParam, BevNodeOutputParam outputParam) {
        return _DoTick (inputParam, outputParam); 
    }

    public void AddChildNode (BevNode node) {
        childNodeList.Add (node); 
    }

    public void SetNodePrecondition (BevNodePrecondition condition) {
        NodePrecondition = condition; 
    }


    protected void SetActiveNode(BevNode node){
        LastActiveNode=ActiveNode;
        ActiveNode=node;
        if(parentNode!=null){
            parentNode.SetActiveNode(node);
        }

    }

    /// <summary>
    /// 内在前提
    /// </summary>
    /// <param name="input">输入</param>
    protected virtual bool _DoEvaluate (BevNodeInputParam input) {
        return true; 
    }
    protected virtual void _DoTransition (BevNodeInputParam input) {}

    protected virtual EBevRunningState _DoTick (BevNodeInputParam inputParam, BevNodeOutputParam outputParam) {
        return EBevRunningState.Finish; 
    }
}