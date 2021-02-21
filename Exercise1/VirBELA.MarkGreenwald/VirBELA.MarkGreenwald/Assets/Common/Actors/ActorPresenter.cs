using Common.Integration;
using Common.Prefabs;
using UnityEngine;
using Zenject;

namespace Common.Actors
{
    /// <summary>
    /// A base presenter for actors providing interface resolution
    /// and actor registry services
    /// </summary>
    public abstract class ActorPresenter : Presenter, IActor
    {
        [SerializeField]
        public Renderer Renderer;

        [SerializeField]
        public Color BaseColor;

        [SerializeField]
        public Color TintColor;

        public Transform Transform => gameObject.transform;

        public bool Tinted { 
            get { return Renderer.material.color != BaseColor; } 
            set { Renderer.material.color = value ? TintColor : BaseColor; }   
        }

        protected IRegistry<IActor> Registry { get; private set; }

        [Inject]
        private void OnInjectRegistry(IRegistry<IActor> registry) {
            Registry = registry;
            registry.Add(this);
            Tinted = false;
        }
    }
}