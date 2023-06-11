// Copyright (c) Meta Platforms, Inc. and affiliates.

using System.Collections.Generic;
using UnityEngine.Events;

public class OVRSkeletonAdjustable : OVRSkeleton {
  public SkeletonPostProcessingEvent SkeletonPostProcessing;

  [System.Serializable] public class SkeletonPostProcessingEvent : UnityEvent<IList<OVRBone>> { }

  protected override void Update() {
    base.Update();
    SkeletonPostProcessing.Invoke(Bones);
  }
}
