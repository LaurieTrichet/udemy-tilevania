using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SceneDescription", menuName = "ScriptableObjects/SceneDescription")]
public class SceneDescriptionSO : ScriptableObject
{

    public string sceneName;
    public string shortDescription;
}
