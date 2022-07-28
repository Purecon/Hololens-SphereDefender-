using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;

public class TestSphereTouch : MonoBehaviour,IMixedRealityTouchHandler
{
    public void OnTouchCompleted(HandTrackingInputEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnTouchStarted(HandTrackingInputEventData eventData)
    {
        Debug.Log("Success");
        throw new System.NotImplementedException();
    }

    public void OnTouchUpdated(HandTrackingInputEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
