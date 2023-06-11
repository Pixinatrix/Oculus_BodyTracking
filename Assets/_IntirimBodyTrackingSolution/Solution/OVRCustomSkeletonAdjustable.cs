// Copyright (c) Meta Platforms, Inc. and affiliates.

using UnityEngine;
#if UNITY_EDITOR
using UnityEditor.SceneManagement;
using UnityEditor;
#endif

public class OVRCustomSkeletonAdjustable : OVRCustomSkeleton {
  public OVRSkeletonAdjustable.SkeletonPostProcessingEvent SkeletonPostProcessing;

  protected override void Update() {
    base.Update();
    SkeletonPostProcessing.Invoke(Bones);
  }
}

#if UNITY_EDITOR
[CustomEditor(typeof(OVRCustomSkeletonAdjustable))]
public class OVRCustomSkeletonEditor : OVRSkeletonEditor {
  public override void OnInspectorGUI() {
    var skeleton = (OVRCustomSkeleton)target;

    base.OnInspectorGUI();


    DrawBonesMapping(skeleton);
  }

  private static void DrawBonesMapping(OVRCustomSkeleton skeleton) {
    if (GUILayout.Button($"Auto Map Bones")) {

      skeleton.AutoMapBones(Hacks.PrivateGet<OVRCustomSkeleton.RetargetingType>(skeleton, "retargetingType"));
      EditorUtility.SetDirty(skeleton);
      EditorSceneManager.MarkSceneDirty(skeleton.gameObject.scene);
    }

    EditorGUILayout.LabelField("Bones", EditorStyles.boldLabel);
    var start = skeleton.GetCurrentStartBoneId();
    var end = skeleton.GetCurrentEndBoneId();
    if (skeleton.IsValidBone(start) && skeleton.IsValidBone(end)) {
      for (var i = (int)start; i < (int)end; ++i) {
        var boneName = OVRSkeleton.BoneLabelFromBoneId(skeleton.GetSkeletonType(), (OVRSkeleton.BoneId)i);
        EditorGUI.BeginChangeCheck();
        var val =
            EditorGUILayout.ObjectField(boneName, skeleton.CustomBones[i], typeof(Transform), true);
        if (EditorGUI.EndChangeCheck()) {
          skeleton.CustomBones[i] = (Transform)val;
          EditorUtility.SetDirty(skeleton);
        }
      }
    }
  }
}
public static class Hacks {
  public static T PrivateGet<T>(object obj, string memberName) {
    System.Reflection.BindingFlags bindFlags = System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic;
    System.Reflection.FieldInfo fi = obj.GetType().GetField(memberName, bindFlags);
    return (T)fi.GetValue(obj);
  }
}
#endif
