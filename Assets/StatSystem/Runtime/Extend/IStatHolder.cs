using UnityEngine;

namespace StatSystem
{
    public interface IStatHolder
    {
        Stat this[int statName] { get; set; }
        Stat Get(int statName);
        void Set(int statName, Stat stat);
    }
}