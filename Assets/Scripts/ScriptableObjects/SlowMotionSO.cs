using UnityEngine;

[CreateAssetMenu(fileName = "SlowMotion", menuName = "ScriptableObjects/SlowMotion")]
public class SlowMotionSO : ScriptableObject
{

    [SerializeField] float fullSpeed = 1.0f;
    [SerializeField] float slowSpeed = .3f;


    public void StartSlowMotion()
    {

        Time.timeScale = slowSpeed;
    }

    public void StopSlowMotion()
    {
        Time.timeScale = fullSpeed;
    }
}
