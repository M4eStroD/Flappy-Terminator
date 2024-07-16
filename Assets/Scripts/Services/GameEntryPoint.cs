using UnityEngine;

public class GameEntryPoint
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void AutostartGame()
    {
        ServiceLocator.Instance.RegisterSingle<IInputService>(new DesktopInputService());

        IDataProvider dataProvider = ServiceLocator.Instance.RegisterSingle<IDataProvider>(new DataProvider());
        dataProvider.Load();
        
        ServiceLocator.Instance.RegisterSingle<IBulletFactory>(new BulletFactory(dataProvider));
        ServiceLocator.Instance.RegisterSingle<IEnemyFactory>(new EnemyFactory(dataProvider));
    }
}
