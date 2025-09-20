using UnityEngine;

namespace StatSystem
{
    public class ReferenceStatHolder : MonoBehaviour, IStatHolder
    {
        [SerializeField] private GameObject _referenceGameObject;

        private IStatHolder _statHolder;

        public GameObject ReferenceGameObject
        {
            get => _referenceGameObject;
            set
            {
                if (_referenceGameObject == value)
                    return;

                _referenceGameObject = value;
                _statHolder = null;

                if (value == null)
                {
                    Debug.LogWarning($"Reference GameObject is null!.");
                    return;
                }

                _statHolder = _referenceGameObject.GetComponent<IStatHolder>();

                if (_statHolder == null)
                {
                    Debug.LogError($"GameObject {_referenceGameObject.name} doesn't contain any IStatholder MonoBehaviour.");
                }
            }
        }


        public Stat this[int statName]
        {
            get => Get(statName);
            set => Set(statName, value);
        }

        public Stat Get(int statName)
        {
            return TryGetStatHolder(out IStatHolder result) ? result[statName] : null; ;
        }

        public void Set(int statName, Stat stat)
        {
            if (TryGetStatHolder(out IStatHolder result))
            {
                result[statName] = stat;
            }
        }

        private bool TryGetStatHolder(out IStatHolder result)
        {
            if (_statHolder != null)
            {
                result = _statHolder;
                return true;
            }

            if (_referenceGameObject == null)
            {
                result = null;
                return false;
            }

            if (_referenceGameObject.TryGetComponent<IStatHolder>(out var statHolder))
            {
                _statHolder = statHolder;
                result = statHolder;
                return true;
            }

            Debug.LogError($"GameObject {_referenceGameObject.name} doesn't contain any IStatholder MonoBehaviour.");

            result = null;
            return false;
        }
    }
}