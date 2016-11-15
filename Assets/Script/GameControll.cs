using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameControll : MonoBehaviour
{

    private const int CACHE_SIZE = 10;

    public GameObject platform;
    public GameObject wall;
    public GameObject diamond;

    private float holeSizeMin;
    private float holeSizeMax;

    private GameObject player;

    private float time;
    private float widthRel;

    private Vector3 lastGroundPosition;
    private Vector3 lastGroundScale;

    private List<CacheElement> objectsCache = new List<CacheElement>();

    private class CacheElement
    {
        public GameObject gameObject;
        public List<GameObject> childs = new List<GameObject>();
    }

    List<CacheElement> Clean(List<CacheElement> objects)
    {
        if(objects.Count == 0)
        {
            return objects;
        }

        List<CacheElement> activeObjects = new List<CacheElement>();

        foreach (CacheElement cache in objects)
        {
            if (cache != null && cache.gameObject.activeSelf)
            {
                Vector3 viewPos = Camera.main.WorldToViewportPoint(cache.gameObject.transform.position);
                if ((viewPos.x + 0.3) < widthRel)
                {
                    Destroy(cache.gameObject);
                    foreach (GameObject gobj in cache.childs)
                    {
                        Destroy(gobj);
                    }
                }
                else
                {
                    activeObjects.Add(cache);
                }
            }
        }

        return activeObjects;
    }

    void Awake()
    {
        player = GameObject.Find("Player");
        widthRel = (this.transform.localScale.y / (Screen.width) / 2);
    }

    // Use this for initialization
    void Start()
    {
        float playerSpeed = player.GetComponent<PlayerController>().GetSpeed();
        holeSizeMin = playerSpeed;
        holeSizeMax = playerSpeed * 2;
        time = Time.time;
        lastGroundPosition = platform.transform.position;
        lastGroundScale = platform.transform.localScale;
    }

    void CreatePlatform()
    {
        GameObject platformClone = Instantiate<GameObject>(platform);
        bool hasHole = false;//(Random.Range(1, 100) <= 15);
        bool hasWall = false;//(Random.Range(1, 100) <= 90);
        bool hasItem = (Random.Range(1, 100) <= 80);

        platformClone.transform.position = lastGroundPosition + (Vector3.right * (lastGroundScale.x +
            ((hasHole) ? Random.Range(holeSizeMin, holeSizeMax) : 0)));

        lastGroundPosition = platformClone.transform.position;

        CacheElement cache = new CacheElement();
        cache.gameObject = platformClone;

        if (!hasHole)
        {
            if(hasWall)
            {
                CreateObject(cache, platformClone, wall, 3.5f, true);
            }
            if(hasItem)
            {
                CreateObject(cache, platformClone, diamond, 3.25f, false);
            }
        }

        objectsCache.Add(cache);
    }

    void CreateObject(CacheElement cache, GameObject ground, GameObject objectToClone, float posY, bool canHasTwo)
    {
        float minX = ground.transform.position.x;
        float maxX = ground.transform.position.x + ground.transform.localScale.x / 2;
        float wx = (Random.Range(minX, maxX)) + 4;
        float randomWz = Random.Range(1, 9);
        float wz = (randomWz <= 3) ? 3 : (randomWz > 3 && randomWz <= 6) ? 0 : -3;
        GameObject obj = Instantiate<GameObject>(objectToClone);
        obj.transform.position = new Vector3(wx, posY, wz);

        cache.childs.Add(obj);

        if (canHasTwo && (Random.Range(1, 100) <= 50))
        {
            GameObject obj2 = Instantiate<GameObject>(objectToClone);
            wz += (wz == -18)?3:(wz == -12)?-3:((Random.Range(1, 100) <= 50))?3:-3;
            obj2.transform.position = new Vector3(wx, posY, wz);
        }    
    }

    // Update is called once per frame
    void Update()
    {
        if(objectsCache.Count <= CACHE_SIZE)
        {
            CreatePlatform();
        }
        else if (Time.time > time)
        {
            objectsCache = Clean(objectsCache);
            time = Time.time + 5f;
        }
    }


}