// Copyright (c) Meta Platforms, Inc. and affiliates.

using Oculus.Interaction.Input;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonHandAdjustment : MonoBehaviour {
  [SerializeField] private Hand hand;
  /// <summary>
  /// used to calculate the user-local space positioning of joints
  /// </summary>
  [SerializeField] private Transform CameraRig;
  /// <summary>
  /// if the camera rig moves but the body is stationary, this should be true
  /// if the camera rig and body move together, this can stay false
  /// </summary>
  [Tooltip("If the camera rig moves but the body is stationary, this should be true.\n" +
    "If the camera rig and body move together, this can stay false.")]
  [SerializeField] private bool _handsAreOffset;
  private SkeletonMap.HandBodyJointPair[] jointPairs = null;
  private Quaternion _rigRotationOffset;
  private Vector3 _rigPositionOffset;

  public bool HandsAreOffset { get => _handsAreOffset; set => _handsAreOffset = value; }

  private void Reset() {
    OVRCameraRig ovrRig = GetComponentInParent<OVRCameraRig>();
    CameraRig = ovrRig != null ? ovrRig.transform : null;
    hand = GetComponentInParent<Hand>();
  }

  public void Start() {
    switch (hand.Handedness) {
      case Handedness.Left: jointPairs = SkeletonMap.LeftHandBodyJointPairs; break;
      case Handedness.Right: jointPairs = SkeletonMap.RightHandBodyJointPairs; break;
    }
  }

  public void SkeletonPostProcess(IList<OVRBone> bones) {
    if (hand == null || jointPairs == null || bones == null || bones.Count == 0 || !hand.IsTrackedDataValid) { return; }
    UpdateRigOffsetCalculations();
    foreach (SkeletonMap.HandBodyJointPair pair in jointPairs) {
      int joint = (int)pair.body;
      if (pair.hand == HandJointId.Invalid || joint < 0) { continue; }
      Transform bone = bones[joint].Transform;
      hand.GetJointPose(pair.hand, out Pose pose);
      if (HandsAreOffset && CameraRig != null) {
        PosePropagationThatUndoesRigTransformation(ref bone, ref pose);
      } else {
        SimplePosePropagation(ref bone, ref pose);
      }
    }
  }

  private void UpdateRigOffsetCalculations() {
    _rigRotationOffset = Quaternion.Inverse(CameraRig.rotation);
    _rigPositionOffset = -CameraRig.position;
  }

  private void SimplePosePropagation(ref Transform bone, ref Pose pose) {
    bone.position = pose.position;
    bone.rotation = pose.rotation;
  }

  private void PosePropagationThatUndoesRigTransformation(ref Transform bone, ref Pose pose) {
    bone.position = _rigRotationOffset * (pose.position + _rigPositionOffset);
    bone.rotation = _rigRotationOffset * pose.rotation;
  }
}
