using UnityEngine;


[CreateAssetMenu(fileName = "MenuPanel", menuName = "ScriptableObjects/MenuPanel")]
public class MenuPanelSO : AbstractPositiveNegativeChoicePanelSO
{
    public PlayerDataSO playerDataSO;
    public override void OnPositiveChoicePressed()
    {
        playerDataSO.ResetPlayer();
        sceneLoader.LoadFirstLevel();
    }

}
