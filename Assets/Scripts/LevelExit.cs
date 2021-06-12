using System.Collections;
using UnityEngine;


public class LevelExit : MonoBehaviour
{
    [SerializeField] string PlayerLayer = "Player";
    [SerializeField] int loadingDelayInSec = 1;

    
    [SerializeField] SceneDescriptionSO nextScene = null;
    [SerializeField] SlowMotionSO exitLevelEffect = null;
    [SerializeField] EnemyReferenceSO enemyReferenceSO = null;

    private LevelController levelController = null;

    private bool isExiting = false;

    private void Awake()
    {
        isExiting = false;

    }

    private void Start()
    {
        if (nextScene == null)
        {
            Debug.LogError("next scene is null, please add a scene to go to.");
        }

        levelController = FindObjectOfType<LevelController>();
        if (levelController == null)
        {
            Debug.LogError("Level Exit requires a LevelController to be in the scene. Please add the LevelController script to the scene.");
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( !isExiting && LayerHelper.AreLayerMatching(collision.gameObject.layer, PlayerLayer))
        {
            isExiting = true;
            Debug.Log("Go to next Level");
            enemyReferenceSO.DesactivateEnemies();
            exitLevelEffect.StartSlowMotion();
            StartCoroutine(ExitLevelCoroutine());
        }
    }



    IEnumerator ExitLevelCoroutine()
    {
        yield return new WaitForSecondsRealtime(loadingDelayInSec);
        exitLevelEffect.StopSlowMotion();
        levelController.OnLevelExit(nextScene);
    }
}
