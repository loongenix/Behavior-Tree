using System.Collections.Generic; 

abstract class  BevNode {
     protected List < BevNode > childNodeList; 
    protected BevNode parentNode {get; set; }

   

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

    public void Transition(BevNodeInputParam input) {
        _DoTransition(input); 
    }
    public virtual BevRunningState Tick(BevNodeInputParam inputParam, BevNodeOutputParam outputParam) {
        return BevRunningState.RUNNING; 
    }

    public void AddChildNode(BevNode node) {
        childNodeList.Add(node);
    }

    public void SetNodePrecondition(BevNodePrecondition condition){
        NodePrecondition=condition;
    }

 /// <summary>
    /// 内在前提
    /// </summary>
    /// <param name="input">输入</param>
    protected virtual bool _DoEvaluate (BevNodeInputParam input) {
        return true; 
    }
    protected abstract void _DoTransition(BevNodeInputParam input); 


}