using UnityEngine;
using VavilichevGD.Utils.Timing;
using Random = UnityEngine.Random;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] private Lifebar lifebar;
    [SerializeField] private Score score;
    [SerializeField] private TargetSpawnTimeRegulator targetSpawnTimeRegulator;
    [SerializeField] private Target target;
    [SerializeField] private Canvas canvas;
    [SerializeField] private RectTransform container;
    
    private SyncedTimer _timer;

    private void OnEnable()
    {
        _timer = new SyncedTimer(TimerType.UpdateTick);

        _timer.TimerFinished += OnTimerFinished;
        
        _timer.Start(targetSpawnTimeRegulator.TargetSpawnTime);
    }

    private void OnDisable()
    {
        _timer.TimerFinished -= OnTimerFinished;
    }

    private void OnTimerFinished()
    {
        SpawnTarget();

        if (lifebar.Health > 0)
            _timer.Start(targetSpawnTimeRegulator.TargetSpawnTime);
    }
    
    private void SpawnTarget()
    {
        Vector2 position = GetRandomPositionInArea(container);

        var spawnedTarget = Instantiate(target, container);
        spawnedTarget.Init(score, lifebar);
        RectTransform rectTransform = spawnedTarget.Rect;
        rectTransform.anchoredPosition = position;
    }

    private Vector2 GetRandomPositionInArea(RectTransform rectTransform)
    {
        Vector2 position;
        Rect rect = RectTransformUtility.PixelAdjustRect(rectTransform, canvas);
        
        position = new Vector2(Random.Range(rect.xMin, rect.xMax), Random.Range(rect.yMin, rect.yMax));
        
        return position;
    }
}
