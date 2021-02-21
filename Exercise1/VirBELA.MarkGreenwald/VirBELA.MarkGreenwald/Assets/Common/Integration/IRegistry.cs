namespace Common.Integration
{
    /// <summary>
    /// Provides registration services for entities of type T
    /// </summary>
    public interface IRegistry<T>
    {
        /// <summary>
        /// The current collection of registered entities
        /// </summary>
        T[] Registrations { get; }

        /// <summary>
        /// Registers a new entity
        /// </summary>
        void Add(T registration);
    }
}