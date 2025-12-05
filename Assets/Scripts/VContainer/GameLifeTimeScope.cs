using Controller;
using ScriptableObject;
using Service;
using UnityEngine;

namespace VContainer
{
    using Unity;
    public class GameLifeTimeScope : LifetimeScope
    {
        
       [SerializeField] private GridConfig gridConfig;
       [SerializeField] private RectTransform rectGrid;
       [SerializeField] private SpriteRenderer gridSpriteRenderer;
       [SerializeField] private LevelDatabase levelDatabase;
 
       protected override void Configure(IContainerBuilder builder)
       { 
           builder.RegisterInstance(gridConfig);
           builder.RegisterInstance(levelDatabase);
           
           builder.RegisterComponent(rectGrid)
               .As<RectTransform>();
           builder.RegisterComponent(gridSpriteRenderer)
               .As<SpriteRenderer>();

           builder.Register<UserService>(Lifetime.Singleton);
           builder.RegisterEntryPoint<GridService>();
           
           builder.Register<LevelService>(Lifetime.Singleton)
               .AsImplementedInterfaces();
       }

    }
}

