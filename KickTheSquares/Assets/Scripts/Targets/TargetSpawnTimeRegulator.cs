using UnityEngine;
using VavilichevGD.Utils.Timing;

public class TargetSpawnTimeRegulator : MonoBehaviour
{
    [SerializeField] private float targetSpawnTimeByDefault = 1.5f;
    [SerializeField] private int timeToUpdateTargetSpawnTime = 5;
    
    public float TargetSpawnTime { get; private set; }

    private SyncedTimer _timer;

    private void OnEnable()
    {
        TargetSpawnTime = targetSpawnTimeByDefault;
        
        _timer = new SyncedTimer(TimerType.OneSecTick);

        _timer.Start(timeToUpdateTargetSpawnTime);

        _timer.TimerFinished += UpdateTargetSpawnTime;
    }

    private void OnDisable()
    {
        _timer.TimerFinished -= UpdateTargetSpawnTime;       
    }

    private void UpdateTargetSpawnTime()
    {
        if (TargetSpawnTime > 0.2f)
        { 
            TargetSpawnTime -= 0.1f;
            _timer.Start(timeToUpdateTargetSpawnTime);
            Debug.Log("Invoked");
        }
    }
}
