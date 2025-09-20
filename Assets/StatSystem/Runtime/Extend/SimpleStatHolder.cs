using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace StatSystem
{
    [Serializable]
    public class StatDefault
    {
        public int StatName;
        public float BaseValue;
    }

    public class SimpleStatHolder : MonoBehaviour, IStatHolder
    {
        [SerializeField] private List<StatDefault> _initList = new();
        [SerializeField] private float _defaultBaseValue = 0;

        private Dictionary<int, Stat> _statTable = new();

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

            StatDefault d = _initList.FirstOrDefault(e => e.StatName == statName);
            float baseValue = d != null ? d.BaseValue : _defaultBaseValue;
            result = new Stat(baseValue);

            _statTable.Add(statName, result);

            return result;
        }

        public void Set(int statName, Stat stat)
        {
            _statTable[statName] = stat;
        }
    }
}