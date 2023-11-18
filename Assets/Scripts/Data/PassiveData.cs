﻿using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(menuName = "Gamejam/Passive", fileName = "New Passive")]
    public class PassiveData : ScriptableObject
    {
        public PropertyKey propertyKey;
        public Operation operation;
        public int value;
    }
}