// (c) Meta Platforms, Inc. and affiliates.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// designed to turn on/off objects with <see cref="UnityEngine.UI.Button"/>
/// </summary>
public class ActivateToggle : MonoBehaviour {
  public List<Set> ToggleSets = new List<Set>();
  public int _index = 0;
  public TextChangeEvent OnSetNameChange;

  [System.Serializable] public class TextChangeEvent : UnityEvent<string> { }

  public int Index {
    get => _index;
    set {
      _index = value;
      Refresh();
    }
  }

  public void SetIndexWithoutNotify(int value) {
    _index = value;
  }

  [System.Serializable]
  public class Set {
    public string name;
    bool active;
    public bool ignored;
    public List<GameObject> objectsToActivate;
    public UnityEvent OnActivate;
    public UnityEvent OnDeactivate;
    public void SetActive(bool active) {
      bool activate = active && !this.active;
      bool deactivate = !active && this.active;
      this.active = active;
      if (activate) { OnActivate.Invoke(); }
      if (deactivate) { OnDeactivate.Invoke(); }
      objectsToActivate.ForEach(o => o?.SetActive(active));
    }
  }

  private void Start() {
    Refresh();
  }

  public void Refresh() {
    for (int i = 0; i < ToggleSets.Count; i++) {
      if (i != _index) {
        ToggleSets[i].SetActive(false);
      }
    }
    for (int i = 0; i < ToggleSets.Count; i++) {
      if (i == _index) {
        ToggleSets[i].SetActive(true);
      }
    }
    OnSetNameChange.Invoke(ToggleSets[_index].name);
  }

  public void Next() {
    if (++_index >= ToggleSets.Count) { _index = 0; }
    if (ToggleSets[_index].ignored) {
      int countValidSets = 0;
      for(int i = 0; i < ToggleSets.Count; ++i) { if (!ToggleSets[i].ignored) { ++countValidSets; } }
      if (countValidSets == 0) { throw new System.Exception("can't set next, all sets are ignored."); }
      Next();
    } else {
      Refresh();
    }
  }

  public void Prev() {
    if (--_index < 0) { _index = ToggleSets.Count - 1; }
    if (ToggleSets[_index].ignored) {
      Prev();
    } else {
      Refresh();
    }
  }
}
