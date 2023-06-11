// Copyright (c) Meta Platforms, Inc. and affiliates.

using System.Collections.Generic;
using Oculus.Interaction.Body.Input;
using Oculus.Interaction.Input;
using UnityEngine;

/// <summary>
/// complementary data for making sense of OVRHand and OVRBody
/// </summary>
public static class SkeletonMap  {
  public static readonly Dictionary<int, int> BodyParent = new Dictionary<int, int> {
    [(int)BodyJointId.Body_Root] = (int)BodyJointId.Invalid,
    [(int)BodyJointId.Body_Hips] = (int)BodyJointId.Body_Root,
    [(int)BodyJointId.Body_SpineLower] = (int)BodyJointId.Body_Hips,
    [(int)BodyJointId.Body_SpineMiddle] = (int)BodyJointId.Body_SpineLower,
    [(int)BodyJointId.Body_SpineUpper] = (int)BodyJointId.Body_SpineMiddle,
    [(int)BodyJointId.Body_Chest] = (int)BodyJointId.Body_SpineUpper,
    [(int)BodyJointId.Body_Neck] = (int)BodyJointId.Body_Chest,
    [(int)BodyJointId.Body_Head] = (int)BodyJointId.Body_Neck,
    [(int)BodyJointId.Body_LeftShoulder] = (int)BodyJointId.Body_Chest,
    [(int)BodyJointId.Body_LeftScapula] = (int)BodyJointId.Body_LeftShoulder,
    [(int)BodyJointId.Body_LeftArmUpper] = (int)BodyJointId.Body_LeftScapula,
    [(int)BodyJointId.Body_LeftArmLower] = (int)BodyJointId.Body_LeftArmUpper,
    [(int)BodyJointId.Body_LeftHandWristTwist] = (int)BodyJointId.Body_LeftArmLower,
    [(int)BodyJointId.Body_RightShoulder] = (int)BodyJointId.Body_Chest,
    [(int)BodyJointId.Body_RightScapula] = (int)BodyJointId.Body_RightShoulder,
    [(int)BodyJointId.Body_RightArmUpper] = (int)BodyJointId.Body_RightScapula,
    [(int)BodyJointId.Body_RightArmLower] = (int)BodyJointId.Body_RightArmUpper,
    [(int)BodyJointId.Body_RightHandWristTwist] = (int)BodyJointId.Body_RightArmLower,
    [(int)BodyJointId.Body_LeftHandWrist] = (int)BodyJointId.Body_LeftArmLower,
    [(int)BodyJointId.Body_LeftHandPalm] = (int)BodyJointId.Body_LeftHandWrist,
    [(int)BodyJointId.Body_LeftHandThumbMetacarpal] = (int)BodyJointId.Body_LeftHandWrist,
    [(int)BodyJointId.Body_LeftHandThumbProximal] = (int)BodyJointId.Body_LeftHandThumbMetacarpal,
    [(int)BodyJointId.Body_LeftHandThumbDistal] = (int)BodyJointId.Body_LeftHandThumbProximal,
    [(int)BodyJointId.Body_LeftHandThumbTip] = (int)BodyJointId.Body_LeftHandThumbDistal,
    [(int)BodyJointId.Body_LeftHandIndexMetacarpal] = (int)BodyJointId.Body_LeftHandWrist,
    [(int)BodyJointId.Body_LeftHandIndexProximal] = (int)BodyJointId.Body_LeftHandIndexMetacarpal,
    [(int)BodyJointId.Body_LeftHandIndexIntermediate] = (int)BodyJointId.Body_LeftHandIndexProximal,
    [(int)BodyJointId.Body_LeftHandIndexDistal] = (int)BodyJointId.Body_LeftHandIndexIntermediate,
    [(int)BodyJointId.Body_LeftHandIndexTip] = (int)BodyJointId.Body_LeftHandIndexDistal,
    [(int)BodyJointId.Body_LeftHandMiddleMetacarpal] = (int)BodyJointId.Body_LeftHandWrist,
    [(int)BodyJointId.Body_LeftHandMiddleProximal] = (int)BodyJointId.Body_LeftHandMiddleMetacarpal,
    [(int)BodyJointId.Body_LeftHandMiddleIntermediate] = (int)BodyJointId.Body_LeftHandMiddleProximal,
    [(int)BodyJointId.Body_LeftHandMiddleDistal] = (int)BodyJointId.Body_LeftHandMiddleIntermediate,
    [(int)BodyJointId.Body_LeftHandMiddleTip] = (int)BodyJointId.Body_LeftHandMiddleDistal,
    [(int)BodyJointId.Body_LeftHandRingMetacarpal] = (int)BodyJointId.Body_LeftHandWrist,
    [(int)BodyJointId.Body_LeftHandRingProximal] = (int)BodyJointId.Body_LeftHandRingMetacarpal,
    [(int)BodyJointId.Body_LeftHandRingIntermediate] = (int)BodyJointId.Body_LeftHandRingProximal,
    [(int)BodyJointId.Body_LeftHandRingDistal] = (int)BodyJointId.Body_LeftHandRingIntermediate,
    [(int)BodyJointId.Body_LeftHandRingTip] = (int)BodyJointId.Body_LeftHandRingDistal,
    [(int)BodyJointId.Body_LeftHandLittleMetacarpal] = (int)BodyJointId.Body_LeftHandWrist,
    [(int)BodyJointId.Body_LeftHandLittleProximal] = (int)BodyJointId.Body_LeftHandLittleMetacarpal,
    [(int)BodyJointId.Body_LeftHandLittleIntermediate] =(int)BodyJointId.Body_LeftHandLittleProximal,
    [(int)BodyJointId.Body_LeftHandLittleDistal] = (int)BodyJointId.Body_LeftHandLittleIntermediate,
    [(int)BodyJointId.Body_LeftHandLittleTip] = (int)BodyJointId.Body_LeftHandLittleDistal,
    [(int)BodyJointId.Body_RightHandWrist] = (int)BodyJointId.Body_RightArmLower,
    [(int)BodyJointId.Body_RightHandPalm] = (int)BodyJointId.Body_RightHandWrist,
    [(int)BodyJointId.Body_RightHandThumbMetacarpal] = (int)BodyJointId.Body_RightHandWrist,
    [(int)BodyJointId.Body_RightHandThumbProximal] = (int)BodyJointId.Body_RightHandThumbMetacarpal,
    [(int)BodyJointId.Body_RightHandThumbDistal] = (int)BodyJointId.Body_RightHandThumbProximal,
    [(int)BodyJointId.Body_RightHandThumbTip] = (int)BodyJointId.Body_RightHandThumbDistal,
    [(int)BodyJointId.Body_RightHandIndexMetacarpal] = (int)BodyJointId.Body_RightHandWrist,
    [(int)BodyJointId.Body_RightHandIndexProximal] = (int)BodyJointId.Body_RightHandIndexMetacarpal,
    [(int)BodyJointId.Body_RightHandIndexIntermediate] =(int)BodyJointId.Body_RightHandIndexProximal,
    [(int)BodyJointId.Body_RightHandIndexDistal] = (int)BodyJointId.Body_RightHandIndexIntermediate,
    [(int)BodyJointId.Body_RightHandIndexTip] = (int)BodyJointId.Body_RightHandIndexDistal,
    [(int)BodyJointId.Body_RightHandMiddleMetacarpal] = (int)BodyJointId.Body_RightHandWrist,
    [(int)BodyJointId.Body_RightHandMiddleProximal] = (int)BodyJointId.Body_RightHandMiddleMetacarpal,
    [(int)BodyJointId.Body_RightHandMiddleIntermediate]=(int)BodyJointId.Body_RightHandMiddleProximal,
    [(int)BodyJointId.Body_RightHandMiddleDistal] = (int)BodyJointId.Body_RightHandMiddleIntermediate,
    [(int)BodyJointId.Body_RightHandMiddleTip] = (int)BodyJointId.Body_RightHandMiddleDistal,
    [(int)BodyJointId.Body_RightHandRingMetacarpal] = (int)BodyJointId.Body_RightHandWrist,
    [(int)BodyJointId.Body_RightHandRingProximal] = (int)BodyJointId.Body_RightHandRingMetacarpal,
    [(int)BodyJointId.Body_RightHandRingIntermediate] = (int)BodyJointId.Body_RightHandRingProximal,
    [(int)BodyJointId.Body_RightHandRingDistal] = (int)BodyJointId.Body_RightHandRingIntermediate,
    [(int)BodyJointId.Body_RightHandRingTip] = (int)BodyJointId.Body_RightHandRingDistal,
    [(int)BodyJointId.Body_RightHandLittleMetacarpal] = (int)BodyJointId.Body_RightHandWrist,
    [(int)BodyJointId.Body_RightHandLittleProximal] = (int)BodyJointId.Body_RightHandLittleMetacarpal,
    [(int)BodyJointId.Body_RightHandLittleIntermediate]=(int)BodyJointId.Body_RightHandLittleProximal,
    [(int)BodyJointId.Body_RightHandLittleDistal] = (int)BodyJointId.Body_RightHandLittleIntermediate,
    [(int)BodyJointId.Body_RightHandLittleTip] = (int)BodyJointId.Body_RightHandLittleDistal,
  };

  public static readonly Dictionary<int, int> HandParent = new Dictionary<int, int> {
    [(int)HandJointId.HandWristRoot] = (int)HandJointId.Invalid,
    [(int)HandJointId.HandForearmStub] = (int)HandJointId.HandWristRoot,
    [(int)HandJointId.HandThumb0] = (int)HandJointId.HandWristRoot,
    [(int)HandJointId.HandThumb1] = (int)HandJointId.HandThumb0,
    [(int)HandJointId.HandThumb2] = (int)HandJointId.HandThumb1,
    [(int)HandJointId.HandThumb3] = (int)HandJointId.HandThumb2,
    [(int)HandJointId.HandIndex1] = (int)HandJointId.HandWristRoot,
    [(int)HandJointId.HandIndex2] = (int)HandJointId.HandIndex1,
    [(int)HandJointId.HandIndex3] = (int)HandJointId.HandIndex2,
    [(int)HandJointId.HandMiddle1] = (int)HandJointId.HandWristRoot,
    [(int)HandJointId.HandMiddle2] = (int)HandJointId.HandMiddle1,
    [(int)HandJointId.HandMiddle3] = (int)HandJointId.HandMiddle2,
    [(int)HandJointId.HandRing1] = (int)HandJointId.HandWristRoot,
    [(int)HandJointId.HandRing2] = (int)HandJointId.HandRing1,
    [(int)HandJointId.HandRing3] = (int)HandJointId.HandRing2,
    [(int)HandJointId.HandPinky0] = (int)HandJointId.HandWristRoot,
    [(int)HandJointId.HandPinky1] = (int)HandJointId.HandPinky0,
    [(int)HandJointId.HandPinky2] = (int)HandJointId.HandPinky1,
    [(int)HandJointId.HandPinky3] = (int)HandJointId.HandPinky2,
    [(int)HandJointId.HandThumbTip] = (int)HandJointId.HandThumb3,
    [(int)HandJointId.HandIndexTip] = (int)HandJointId.HandIndex3,
    [(int)HandJointId.HandMiddleTip] = (int)HandJointId.HandMiddle3,
    [(int)HandJointId.HandRingTip] = (int)HandJointId.HandRing3,
    [(int)HandJointId.HandPinkyTip] = (int)HandJointId.HandPinky3,
  };

  [System.Serializable] public struct HandBodyJointPair {
    public HandJointId hand;
    public BodyJointId body;
    public HandBodyJointPair(HandJointId hand, BodyJointId body) { this.hand = hand; this.body = body; }
    public static implicit operator HandBodyJointPair((HandJointId hand, BodyJointId body) tuple) => new HandBodyJointPair(tuple.hand, tuple.body);
  }

  public static readonly HandBodyJointPair[][] LeftHandBodyJointPairsByFinger = {
    new HandBodyJointPair[] {
      (HandJointId.HandWristRoot, BodyJointId.Body_LeftHandWrist),
      (HandJointId.HandForearmStub, BodyJointId.Body_LeftHandPalm),
    }, new HandBodyJointPair[] {
      (HandJointId.HandThumb0, BodyJointId.Invalid),
      (HandJointId.HandThumb1, BodyJointId.Body_LeftHandThumbMetacarpal),
      (HandJointId.HandThumb2, BodyJointId.Body_LeftHandThumbProximal),
      (HandJointId.HandThumb3, BodyJointId.Body_LeftHandThumbDistal),
      (HandJointId.HandThumbTip, BodyJointId.Body_LeftHandThumbTip),
    }, new HandBodyJointPair[] {
      (HandJointId.Invalid, BodyJointId.Body_LeftHandIndexMetacarpal),
      (HandJointId.HandIndex1, BodyJointId.Body_LeftHandIndexProximal),
      (HandJointId.HandIndex2, BodyJointId.Body_LeftHandIndexIntermediate),
      (HandJointId.HandIndex3, BodyJointId.Body_LeftHandIndexDistal),
      (HandJointId.HandIndexTip, BodyJointId.Body_LeftHandIndexTip),
    }, new HandBodyJointPair[] {
      (HandJointId.Invalid, BodyJointId.Body_LeftHandMiddleMetacarpal),
      (HandJointId.HandMiddle1, BodyJointId.Body_LeftHandMiddleProximal),
      (HandJointId.HandMiddle2, BodyJointId.Body_LeftHandMiddleIntermediate),
      (HandJointId.HandMiddle3, BodyJointId.Body_LeftHandMiddleDistal),
      (HandJointId.HandMiddleTip, BodyJointId.Body_LeftHandMiddleTip),
    }, new HandBodyJointPair[] {
      (HandJointId.Invalid, BodyJointId.Body_LeftHandRingMetacarpal),
      (HandJointId.HandRing1, BodyJointId.Body_LeftHandRingProximal),
      (HandJointId.HandRing2, BodyJointId.Body_LeftHandRingIntermediate),
      (HandJointId.HandRing3, BodyJointId.Body_LeftHandRingDistal),
      (HandJointId.HandRingTip, BodyJointId.Body_LeftHandRingTip),
    }, new HandBodyJointPair[] {
      (HandJointId.HandPinky0, BodyJointId.Body_LeftHandLittleMetacarpal),
      (HandJointId.HandPinky1, BodyJointId.Body_LeftHandLittleProximal),
      (HandJointId.HandPinky2, BodyJointId.Body_LeftHandLittleIntermediate),
      (HandJointId.HandPinky3, BodyJointId.Body_LeftHandLittleDistal),
      (HandJointId.HandPinkyTip, BodyJointId.Body_LeftHandLittleTip),
    },
  };

  public static readonly HandBodyJointPair[][] RightHandBodyJointPairsByFinger = {
    new HandBodyJointPair[] {
      (HandJointId.HandWristRoot, BodyJointId.Body_RightHandWrist),
      (HandJointId.HandForearmStub, BodyJointId.Body_RightHandPalm),
    }, new HandBodyJointPair[] {
      (HandJointId.HandThumb0, BodyJointId.Invalid),
      (HandJointId.HandThumb1, BodyJointId.Body_RightHandThumbMetacarpal),
      (HandJointId.HandThumb2, BodyJointId.Body_RightHandThumbProximal),
      (HandJointId.HandThumb3, BodyJointId.Body_RightHandThumbDistal),
      (HandJointId.HandThumbTip, BodyJointId.Body_RightHandThumbTip),
    }, new HandBodyJointPair[] {
      (HandJointId.Invalid, BodyJointId.Body_RightHandIndexMetacarpal),
      (HandJointId.HandIndex1, BodyJointId.Body_RightHandIndexProximal),
      (HandJointId.HandIndex2, BodyJointId.Body_RightHandIndexIntermediate),
      (HandJointId.HandIndex3, BodyJointId.Body_RightHandIndexDistal),
      (HandJointId.HandIndexTip, BodyJointId.Body_RightHandIndexTip),
    }, new HandBodyJointPair[] {
      (HandJointId.Invalid, BodyJointId.Body_RightHandMiddleMetacarpal),
      (HandJointId.HandMiddle1, BodyJointId.Body_RightHandMiddleProximal),
      (HandJointId.HandMiddle2, BodyJointId.Body_RightHandMiddleIntermediate),
      (HandJointId.HandMiddle3, BodyJointId.Body_RightHandMiddleDistal),
      (HandJointId.HandMiddleTip, BodyJointId.Body_RightHandMiddleTip),
    }, new HandBodyJointPair[] {
      (HandJointId.Invalid, BodyJointId.Body_RightHandRingMetacarpal),
      (HandJointId.HandRing1, BodyJointId.Body_RightHandRingProximal),
      (HandJointId.HandRing2, BodyJointId.Body_RightHandRingIntermediate),
      (HandJointId.HandRing3, BodyJointId.Body_RightHandRingDistal),
      (HandJointId.HandRingTip, BodyJointId.Body_RightHandRingTip),
    }, new HandBodyJointPair[] {
      (HandJointId.HandPinky0, BodyJointId.Body_RightHandLittleMetacarpal),
      (HandJointId.HandPinky1, BodyJointId.Body_RightHandLittleProximal),
      (HandJointId.HandPinky2, BodyJointId.Body_RightHandLittleIntermediate),
      (HandJointId.HandPinky3, BodyJointId.Body_RightHandLittleDistal),
      (HandJointId.HandPinkyTip, BodyJointId.Body_RightHandLittleTip),
    },
  };

  public static readonly HandBodyJointPair[] LeftHandBodyJointPairs = {
    (HandJointId.HandWristRoot, BodyJointId.Body_LeftHandWrist),
    (HandJointId.HandForearmStub, BodyJointId.Body_LeftHandPalm),
    (HandJointId.HandThumb0, BodyJointId.Invalid),
    (HandJointId.HandThumb1, BodyJointId.Body_LeftHandThumbMetacarpal),
    (HandJointId.HandThumb2, BodyJointId.Body_LeftHandThumbProximal),
    (HandJointId.HandThumb3, BodyJointId.Body_LeftHandThumbDistal),
    (HandJointId.HandThumbTip, BodyJointId.Body_LeftHandThumbTip),
    (HandJointId.Invalid, BodyJointId.Body_LeftHandIndexMetacarpal),
    (HandJointId.HandIndex1, BodyJointId.Body_LeftHandIndexProximal),
    (HandJointId.HandIndex2, BodyJointId.Body_LeftHandIndexIntermediate),
    (HandJointId.HandIndex3, BodyJointId.Body_LeftHandIndexDistal),
    (HandJointId.HandIndexTip, BodyJointId.Body_LeftHandIndexTip),
    (HandJointId.Invalid, BodyJointId.Body_LeftHandMiddleMetacarpal),
    (HandJointId.HandMiddle1, BodyJointId.Body_LeftHandMiddleProximal),
    (HandJointId.HandMiddle2, BodyJointId.Body_LeftHandMiddleIntermediate),
    (HandJointId.HandMiddle3, BodyJointId.Body_LeftHandMiddleDistal),
    (HandJointId.HandMiddleTip, BodyJointId.Body_LeftHandMiddleTip),
    (HandJointId.Invalid, BodyJointId.Body_LeftHandRingMetacarpal),
    (HandJointId.HandRing1, BodyJointId.Body_LeftHandRingProximal),
    (HandJointId.HandRing2, BodyJointId.Body_LeftHandRingIntermediate),
    (HandJointId.HandRing3, BodyJointId.Body_LeftHandRingDistal),
    (HandJointId.HandRingTip, BodyJointId.Body_LeftHandRingTip),
    (HandJointId.HandPinky0, BodyJointId.Body_LeftHandLittleMetacarpal),
    (HandJointId.HandPinky1, BodyJointId.Body_LeftHandLittleProximal),
    (HandJointId.HandPinky2, BodyJointId.Body_LeftHandLittleIntermediate),
    (HandJointId.HandPinky3, BodyJointId.Body_LeftHandLittleDistal),
    (HandJointId.HandPinkyTip, BodyJointId.Body_LeftHandLittleTip),
  };

  public static readonly HandBodyJointPair[] RightHandBodyJointPairs = {
    (HandJointId.HandWristRoot, BodyJointId.Body_RightHandWrist),
    (HandJointId.HandForearmStub, BodyJointId.Body_RightHandPalm),
    (HandJointId.HandThumb0, BodyJointId.Invalid),
    (HandJointId.HandThumb1, BodyJointId.Body_RightHandThumbMetacarpal),
    (HandJointId.HandThumb2, BodyJointId.Body_RightHandThumbProximal),
    (HandJointId.HandThumb3, BodyJointId.Body_RightHandThumbDistal),
    (HandJointId.HandThumbTip, BodyJointId.Body_RightHandThumbTip),
    (HandJointId.Invalid, BodyJointId.Body_RightHandIndexMetacarpal),
    (HandJointId.HandIndex1, BodyJointId.Body_RightHandIndexProximal),
    (HandJointId.HandIndex2, BodyJointId.Body_RightHandIndexIntermediate),
    (HandJointId.HandIndex3, BodyJointId.Body_RightHandIndexDistal),
    (HandJointId.HandIndexTip, BodyJointId.Body_RightHandIndexTip),
    (HandJointId.Invalid, BodyJointId.Body_RightHandMiddleMetacarpal),
    (HandJointId.HandMiddle1, BodyJointId.Body_RightHandMiddleProximal),
    (HandJointId.HandMiddle2, BodyJointId.Body_RightHandMiddleIntermediate),
    (HandJointId.HandMiddle3, BodyJointId.Body_RightHandMiddleDistal),
    (HandJointId.HandMiddleTip, BodyJointId.Body_RightHandMiddleTip),
    (HandJointId.Invalid, BodyJointId.Body_RightHandRingMetacarpal),
    (HandJointId.HandRing1, BodyJointId.Body_RightHandRingProximal),
    (HandJointId.HandRing2, BodyJointId.Body_RightHandRingIntermediate),
    (HandJointId.HandRing3, BodyJointId.Body_RightHandRingDistal),
    (HandJointId.HandRingTip, BodyJointId.Body_RightHandRingTip),
    (HandJointId.HandPinky0, BodyJointId.Body_RightHandLittleMetacarpal),
    (HandJointId.HandPinky1, BodyJointId.Body_RightHandLittleProximal),
    (HandJointId.HandPinky2, BodyJointId.Body_RightHandLittleIntermediate),
    (HandJointId.HandPinky3, BodyJointId.Body_RightHandLittleDistal),
    (HandJointId.HandPinkyTip, BodyJointId.Body_RightHandLittleTip),
  };

  /// <summary>
  /// converts joint rotation from OVRHand into joint rotation more compatable with OVRBody
  /// </summary>
  /// <param name="ovrHand">which hand is being read (will have an internal left/right set)</param>
  /// <param name="boneId">integer version of OVRPlugin.BoneId</param>
  public static Quaternion GetRotationFromWrist(OVRHand ovrHand, int boneId) {
    var skeleton  = ovrHand as OVRSkeleton.IOVRSkeletonDataProvider;
    var nativeRotations = skeleton.GetSkeletonPoseData().BoneRotations;
    if (nativeRotations == null) { return Quaternion.identity; }
    return GetRotationFromWrist(nativeRotations, boneId);
  }

  public static Quaternion GetRotationFromWrist(OVRPlugin.Quatf[] nativeRotations, int boneId) {
    Quaternion rotation = nativeRotations[boneId].FromFlippedXQuatf();
    int parentId = HandParent[boneId];//HandSkeleton.DefaultLeftSkeleton.joints[boneId].parent;
    if (parentId <= (int)OVRPlugin.BoneId.Hand_Start) { return rotation; }
    Quaternion parentRotation = GetRotationFromWrist(nativeRotations, parentId);
    return parentRotation * rotation;
  }
}
