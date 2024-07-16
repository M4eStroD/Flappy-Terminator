using UnityEngine;

[CreateAssetMenu(fileName = "new bullet", menuName = "StaticData/Bullet", order = 51)]
public class BulletData : ScriptableObject
{
    [SerializeField] private string _id;
    [SerializeField] private Bullet _prefab; 

    public string ID => _id;
    public Bullet Prefab => _prefab;
}
