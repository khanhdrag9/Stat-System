using System.Collections.Generic;

namespace StatSystem
{
    public class NonBehaviourStatHolder : IStatHolder
    {
        private Dictionary<int, Stat> _statTable = new();
        private float _defaultBaseValue;

        public NonBehaviourStatHolder(float defaultValue = 1)
        {
            _defaultBaseValue = defaultValue;
        }

        public Stat this[int statName]
        {
            get => Get(statName);
            set => Set(statName, value);
        } 

        public Stat Get(int statName)
        {
            if (_statTable.TryGetValue(statName, out Stat result))
            {
                return result;
            }

            result = new Stat(_defaultBaseValue);
            _statTable[statName] = result;

            return result;
        }

        public void Set(int statName, Stat stat)
        {
            _statTable[statName] = stat;
        }
    }
}