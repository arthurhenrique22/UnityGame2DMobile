using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using BBUnity.Conditions;

[Condition("Game/Perception/IsTargetVisible")]
public class IsTargetVisible : GOCondition
{
    [InParam("Target")]
    private GameObject target;
    
    [InParam("AIVision")]
    private AIVision aiVision;
    
    [InParam("TargetMemoryDuration")]
    private float targetMemoryDuration;
    private float forgetTargetTime;
    public override bool Check()
    {
        if(aiVision.IsVisible(target))
        {
            forgetTargetTime = Time.time + targetMemoryDuration;
            return true;

        }
        return Time.time < forgetTargetTime;
    }
}
