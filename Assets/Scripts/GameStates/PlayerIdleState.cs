using UnityEngine;
using UnityEditor;
using TheLiquidFire.AspectContainer;

public class PlayerIdleState : BaseState
{
    public override void Enter()
    {
        Temp_AutoChangeTurnForAI();
    }

    void Temp_AutoChangeTurnForAI()
    {
        if(container.GetMatch().GetCurrentPlayer().controlMode != ControlModes.User)
        {
            Debug.Log("Current player is AI; changing turn ...");
            container.GetAspect<MatchSystem>().ChangeTurn();
        }
    }
}
 