using UnityEngine;
using System.Collections;

public class Tags : MonoBehaviour
{
    public string playerTag = "Player";
    public string playerOneTag = "PlayerOne";
    public string playerTwoTag = "PlayerTwo";
    public string enemyTag = "EnemyTag";
    public string bulletProjectileTag = "BulletTag";
    public string collectableTag = "CollectableTag";
    public string KeyItemTag = "KeyItemTag";
    public string GroundTag = "GroundTag";
    public string WallTag = "WallTag";
    public string strongBulletTag = "StrongBulletTag";
    public string WeakBulletTag = "WeakBulletTag";
    public string enemySpawnPointTag = "EnemySpawnPointTag";

    public void GiveTag(string tag, GameObject go)
    {
        go.tag = tag;
    }

}
