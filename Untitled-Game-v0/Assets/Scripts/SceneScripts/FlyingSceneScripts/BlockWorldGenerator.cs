using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockWorldGenerator : MonoBehaviour
{
    [SerializeField]
    public Transform prefab;

    public Transform player;
    public float spawnBoundry = 150f;
    public float worldSpread = 200f;
    public int worldPoints = 100;
    public int worldDensity = 24;

    List<DiskPoint> landObjects = new List<DiskPoint>();
    Vector3 lastSpawnPoint;
    float fillRadius;
    Color[] colors = {Color.red, Color.white, Color.black, Color.yellow, Color.green};

    void Start()
    {
        lastSpawnPoint = player.position;
        fillRadius = 1.5f * spawnBoundry;

        SpawnWorld(ref landObjects, worldPoints, worldDensity, fillRadius, true);
    }

    void Update()
    {
        if (GetSqrHorizontalDist(lastSpawnPoint, player.position) > spawnBoundry * spawnBoundry)
        {
            RemoveOuterLands(ref landObjects, player.position, fillRadius); //clearing lands first will be more efficient
            SpawnWorld(ref landObjects, worldPoints, worldDensity, fillRadius);
            lastSpawnPoint = player.position;
        }
    }


    float GetSqrHorizontalDist(Vector3 pointA, Vector3 pointB)
    {
        pointA.y = 0f;
        pointB.y = 0f;
        return (pointB - pointA).sqrMagnitude;
    }

    void SpawnWorld(ref List<DiskPoint> landObjects, int numPoints, int density, float threashold, bool initialSpawn = false)
    {
        List<DiskPoint> diskPoints = GenerateDiskPoints(player.position, numPoints, worldSpread);

        //preform random shuffle -> do first to limit how many points need to go through
        DiskPoint[] shuffledPoints = Utility.FisherYatesArrayShuffle(diskPoints.ToArray());

        //select top howevermany points
        density = Mathf.Clamp(density, 0, numPoints);
        //select all point in range(limit to having to be a certian distance form current location and previous location)
        for (int i = 0; i < density; i++)
        {
            DiskPoint diskPoint = shuffledPoints[i];
            if ((GetSqrHorizontalDist(lastSpawnPoint, diskPoint.position) > threashold * threashold) || initialSpawn)
            {
                //for each point spawn a land
                diskPoint.InstatiateObject();
                landObjects.Add(diskPoint);
            }
        }
        lastSpawnPoint = player.position;
    }

    void RemoveOuterLands(ref List<DiskPoint> landObjects, Vector3 newSpawnPos, float threashold)
    {
        List<DiskPoint> toRemove = new List<DiskPoint>();
        foreach(DiskPoint diskPoint in landObjects)
        {
            if(GetSqrHorizontalDist(diskPoint.position, newSpawnPos) > threashold * threashold)
            {
                diskPoint.DestroyObject();
                toRemove.Add(diskPoint);
            }
        }
        foreach(DiskPoint diskPoint in toRemove)
        {
            landObjects.Remove(diskPoint);
        }
    }

    List<DiskPoint> GenerateDiskPoints(Vector3 origin, int numPoints, float spread)
    {
        float pow = .5f;//same as sqrt
        float turnFraction = (1 + Mathf.Sqrt(5)) / 2;//golden ratio
        List<DiskPoint> diskPoints = new List<DiskPoint>();
        Color color = Random.ColorHSV();

        for (int i = 0; i < numPoints; i ++)
        {
            float dst = Mathf.Pow(i / (numPoints - 1f), pow) * spread;
            float angle = 2 * Mathf.PI * turnFraction * i;

            float x = dst * Mathf.Cos(angle);
            float z = dst * Mathf.Sin(angle);

            DiskPoint point = new DiskPoint(prefab, this.transform, color, x + origin.x, z + origin.z);
            diskPoints.Add(point);
        }

        return diskPoints;
    }

    struct DiskPoint
    {
        public Vector3 position;

        Transform obj;
        Transform parent;
        Transform prefab;
        Color color;

        public DiskPoint(Transform _prefab, Transform _parent, Color _color, float x, float z)
        {
            parent = _parent;
            prefab = _prefab;
            color = _color;

            position = new Vector3(x, 0, z);
            obj = null;
        }

        public void InstatiateObject()
        {
            obj = Instantiate(prefab, position, Quaternion.identity, parent) as Transform;
            obj.localScale = new Vector3(Random.Range(1,50), Random.Range(1, 50), Random.Range(1, 50));
            obj.GetComponent<Renderer>().material.color = color;
        }

        public void DestroyObject()
        {
            Destroy(obj.gameObject);
        }
    }


}
