using UnityEngine;

namespace StatSystem
{
    public class NonBehaviourReferenceStatHolder : IStatHolder
    {
        public IStatHolder ReferenceStatHoler;

        public NonBehaviourReferenceStatHolder() {}

        public NonBehaviourReferenceStatHolder(IStatHolder reference)
        {
            ReferenceStatHoler = reference;
        }

        public Stat this[int statName]
        {
            get => Get(statName);
            set => Set(statName, value);
        }

        public Stat Get(int statName)
        {
            return ReferenceStatHoler != null ? ReferenceStatHoler[statName] : null;
        }

        public void Set(int statName, Stat stat)
        {
            if (ReferenceStatHoler != null)
            {
                ReferenceStatHoler[statName] = stat;
            }
        }
    }
}