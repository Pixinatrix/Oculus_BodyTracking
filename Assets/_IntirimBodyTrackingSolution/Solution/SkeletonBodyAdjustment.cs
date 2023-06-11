using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction.Body.Input;


public class SkeletonBodyAdjustment : MonoBehaviour {
  [SerializeField] private Body body;

  public void SkeletonPostProcess(IList<OVRBone> bones) {
    if (body == null || bones == null || bones.Count == 0 || !enabled) { return; }
    for (int i = 0; i < (int)BodyJointId.Body_End; ++i) {
      Transform bone = bones[i].Transform;
      body.GetJointPose((BodyJointId)i, out Pose pose);
      bone.position = pose.position;
      bone.rotation = pose.rotation;
    }
  }
}
