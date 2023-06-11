// Copyright (c) Meta Platforms, Inc. and affiliates.

using UnityEngine;

public class TransformsFollow : MonoBehaviour {
  public Transform[] FollowingTransforms;

  protected void LateUpdate() {
    if (FollowingTransforms == null || FollowingTransforms.Length == 0) { return; }
    Transform self = transform;
    foreach (Transform t in FollowingTransforms) {
      t.position = self.position;
      t.rotation = self.rotation;
    }
  }

  public void SetTransformsToZero() {
    foreach (Transform t in FollowingTransforms) {
      t.localPosition = Vector3.zero;
      t.localRotation = Quaternion.identity;
    }
  }
}
