using UnityEngine;

[CreateAssetMenu(fileName = "new enemy", menuName = "StaticData/Enemy", order = 51)]
public class EnemyData : ScriptableObject
{
    [SerializeField] private string _id;
    [SerializeField] private Enemy _prefab;

    public string ID => _id;
    public Enemy Prefab => _prefab;
}