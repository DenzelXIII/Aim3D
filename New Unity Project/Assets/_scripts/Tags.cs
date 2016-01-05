using UnityEngine;
using System.Collections;

public class Tags : MonoBehaviour
{
    public string playerTag = "Player";
    public string enemyTag = "EnemyTag";
    public string bulletProjectileTag = "BulletTag";
    public string collectableTag = "CollectableTag";
    public string KeyItemTag = "KeyItemTag";
    public string GroundTag = "GroundTag";
    public string WallTag = "WallTag";

    public void GIveTag(string tag, GameObject go)
    {
        go.tag = tag;
    }

}
