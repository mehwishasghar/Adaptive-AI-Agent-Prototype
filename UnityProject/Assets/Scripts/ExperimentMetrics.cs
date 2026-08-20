using System.Collections.Generic;
using System.IO;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Profiling;

public class ExperimentMetrics : MonoBehaviour
{
    public SimpleAgent agent;
    public Transform target;

    [Header("Experiment")]
    public float experimentDuration = 30f;

    private float elapsedTime;
    private float fpsTimer;
    private int frameCount;

    private int decisionStart;
    private bool targetReached;

    private ProfilerRecorder mainThreadRecorder;
    private ProfilerRecorder memoryRecorder;

    private List<string> data = new List<string>();

    void Start()
    {
        
        Debug.Log("EXPERIMENT METRICS STARTED");
        if (agent == null)
            agent = FindObjectOfType<SimpleAgent>();

        if (target == null)
        {
            GameObject targetObject = GameObject.Find("Target");

            if (targetObject != null)
                target = targetObject.transform;
        }

        decisionStart = agent.GetDecisionCount();

        mainThreadRecorder =
            ProfilerRecorder.StartNew(
                ProfilerCategory.Internal,
                "Main Thread"
            );

        memoryRecorder =
            ProfilerRecorder.StartNew(
                ProfilerCategory.Memory,
                "System Used Memory"
            );

        data.Add(
            "Time,FPS,CPU_ms,Memory_MB,Decisions,TargetReached"
        );
    }

    void Update()
    {
        
        if (agent == null)
            return;

        elapsedTime += Time.deltaTime;

        frameCount++;
        fpsTimer += Time.deltaTime;

        if (fpsTimer >= 1f)
        {
            float fps =
                frameCount / fpsTimer;

            float cpuMs =
                mainThreadRecorder.LastValue / 1000000f;

            float memoryMB =
                memoryRecorder.LastValue /
                (1024f * 1024f);

            int decisions =
                agent.GetDecisionCount()
                - decisionStart;

            targetReached =
                agent.HasReachedTarget();

            data.Add(
                elapsedTime.ToString("F2") + "," +
                fps.ToString("F2") + "," +
                cpuMs.ToString("F2") + "," +
                memoryMB.ToString("F2") + "," +
                decisions + "," +
                targetReached
            );

            frameCount = 0;
            fpsTimer = 0f;
        }

        if (elapsedTime >= experimentDuration)
        {
            SaveResults();
            enabled = false;
        }
    }

    void SaveResults()
    {
        string dataPath =
            Path.Combine(
                Application.dataPath,
                "Data"
            );

        if (!Directory.Exists(dataPath))
            Directory.CreateDirectory(dataPath);

        string fileName =
            "experiment_" +
            agent.aiLevel.ToString() +
            ".csv";

        string fullPath =
            Path.Combine(
                dataPath,
                fileName
            );

        File.WriteAllLines(
            fullPath,
            data
        );

        Debug.Log(
            "================================"
        );

        Debug.Log(
            "EXPERIMENT COMPLETE"
        );

        Debug.Log(
            "AI Level: " +
            agent.aiLevel
        );

        Debug.Log(
            "Decisions: " +
            (agent.GetDecisionCount() - decisionStart)
        );

        Debug.Log(
            "Target Reached: " +
            agent.HasReachedTarget()
        );

        Debug.Log(
            "Results saved to:"
        );

        Debug.Log(fullPath);

        Debug.Log(
            "================================"
        );

        mainThreadRecorder.Dispose();
        memoryRecorder.Dispose();
    }

    void OnDestroy()
    {
        if (mainThreadRecorder.Valid)
            mainThreadRecorder.Dispose();

        if (memoryRecorder.Valid)
            memoryRecorder.Dispose();
    }
}