using UnityEngine;


[CreateAssetMenu(fileName = "GameWonPanel", menuName = "ScriptableObjects/GameWonPanel")]
public class GameWonPanelSO : AbstractPositiveNegativeChoicePanelSO
{
    public override void OnPositiveChoicePressed()
    {
        sceneLoader.LoadFirstLevel();
    }

}
