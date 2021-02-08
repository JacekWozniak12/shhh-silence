using UnityEngine;
using System;
using UnityEngine.Events;

namespace ShhhSilence.Game.Behaviours
{
    public class IntValueChanger : MonoBehaviour
    {
        [SerializeField]
        private int value = 100;

        [SerializeField]
        private int maxValue = 100;

        public int MaxValue { get => maxValue; private set => maxValue = value; }
        public int Value { get => value; private set => this.value = value; }

        public UnityEvent<int> ValueZeroOrBelow;
        public UnityEvent<int> ValueAdded;
        public UnityEvent<int> ValueSubtracted;

        public void SetStartingValue(int value) => SetStartingValue(value, value);

        public void SetStartingValue(int value, int maxValue)
        {
            MaxValue = value;
            Value = value;
        }

        /// <summary>
        /// Subtracts absolute amount to entity health
        /// </summary>
        public void SubtractFromValue(int amount)
        {
            Value -= Mathf.Abs(amount);
            if (Value <= 0)
            {
                ValueZeroOrBelow?.Invoke(Value);
                return;
            }
            ValueAdded?.Invoke(Value);
        }

        /// <summary>
        /// Adds absolute amount to entity health. 
        /// If above maximum level, then sets it to maximum
        /// </summary>
        public void AddToValue(int amount)
        {
            Value += Mathf.Abs(amount);
            if (Value > MaxValue) Value = MaxValue;
            ValueSubtracted?.Invoke(Value);
        }
    }
}

