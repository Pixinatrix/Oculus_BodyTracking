// Copyright (c) Meta Platforms, Inc. and affiliates.

using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// If a tracked skeleton's rigged mesh transform is stationary, this script
/// will translate the tracked skeleton's position/rotation to this object.
/// </summary>
public class SkeletonTranslate : MonoBehaviour
{
  public void Start() {
	// any Start method (even empty) creates enable toggle in the Unity editor
  }
  public void SkeletonPostProcess(IList<OVRBone> bones) {
	if (bones == null || bones.Count == 0 || !enabled) return;
	Transform t = transform;
	Vector3 p = t.position;
	Quaternion r = t.rotation;
	for (int i = 0; i < bones.Count; ++i) {
	  Transform bone = bones[i].Transform;
	  bone.position = p + r * bone.position;
	  bone.rotation = r * bone.rotation;
	}
  }
}
