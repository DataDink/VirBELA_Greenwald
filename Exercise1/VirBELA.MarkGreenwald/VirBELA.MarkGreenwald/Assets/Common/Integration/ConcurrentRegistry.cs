using System.Collections.Concurrent;

namespace Common.Integration
{
    /// <summary>
    /// Concurrency is not really needed for modern Unity since it's single threaded
    /// but this is an easy win to auto-upgrade should that ever change
    /// </summary>
    public class ConcurrentRegistry<T> : IRegistry<T>
    {
        private readonly ConcurrentBag<T> _registry = new ConcurrentBag<T>();

        public T[] Registrations => _registry.ToArray();

        public void Add(T registration) {
            _registry.Add(registration);
        }
    }
}