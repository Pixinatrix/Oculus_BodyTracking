using System;
using System.Collections;
using System.Collections.Generic;
using Oculus.Movement.AnimationRigging;
using Oculus.Movement.AnimationRigging.Utils;
using UnityEngine;


public class RetargetLayerFixed : RetargetingLayer {
  [System.Serializable] public class SkeletonPostProcessingEvent : UnityEngine.Events.UnityEvent<IList<OVRBone>> { } // <--- added by MichaelV
  [SerializeField] protected SkeletonPostProcessingEvent SkeletonPostProcessing; // <--- added by MichaelV
  protected override void Update() {
    Hacks.PrivateCall(this, "DisableAvatarIfNecessary");

    UpdateSkeleton();
    SkeletonPostProcessing.Invoke(Bones);
    RecomputeSkeletalOffsetsIfNecessary();

    if (Hacks.PrivateGet<bool>(this,"_enableTrackingByProxy")) {
      Hacks.PrivateGet<ProxyTransformLogic>(this, "_proxyTransformLogic").UpdateState(Bones);
    }
  }

  public static class Hacks {
    public static T PrivateGet<T>(object obj, string memberName) {
      System.Reflection.BindingFlags bindFlags = System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic;
      System.Reflection.FieldInfo fi = obj.GetType().GetField(memberName, bindFlags);
      return (T)fi.GetValue(obj);
    }
    public static void PrivateCall(object obj, string methodName) {
      System.Reflection.BindingFlags bindFlags = System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic;
      System.Reflection.MethodInfo mi = obj.GetType().GetMethod(methodName, bindFlags);
      mi.Invoke(obj, Array.Empty<object>());
    }
  }
}
