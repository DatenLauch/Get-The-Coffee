using UnityEngine;

public class SpawnBeans: MonoBehaviour
{
    [SerializeField] private GameObject Collectable;
    [SerializeField] private int CountOfCollectablesToSpawn = 1;
    private float timer = 0f; // Keeps track of the time passed
    [SerializeField] private float interval = 1f; // Interval in seconds (default is 1 second)
    
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            SpawnCollectables();
            timer = 0f;
        }
        
    }

    private void SpawnCollectables()
    {
        for (int i = 0; i < CountOfCollectablesToSpawn; i++)
        {
            Instantiate(Collectable, new Vector3(363, 516, -97), Quaternion.identity);
        }
    }
}
