using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace roman.demidow.game
{
    public class MiniopnHolder : MonoBehaviour
    {
        private List<Minion> _minions;

        public void Init()
        {
            _minions = FindObjectsOfType<Minion>().ToList();

            foreach (Minion minion in _minions)
            {
                minion.Init();
            }

            SetParentForMinions(transform);
        }

        private void SetParentForMinions(Transform parent)
        {
            foreach (Minion minion in _minions)
            {
                minion.transform.SetParent(parent);
            }
        }
    }
}