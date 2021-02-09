using UnityEngine.Events;

namespace ShhhSilence.Base.Interfaces
{
    public interface IEventInteractable<T0>
    {
        void Interact(T0 t0);
        void AddListener(UnityAction<T0> action);
        void RemoveListener(UnityAction<T0> action);
    }
}