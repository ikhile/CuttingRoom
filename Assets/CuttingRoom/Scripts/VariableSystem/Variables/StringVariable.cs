﻿using CuttingRoom.Editor;
using System;
using UnityEngine;

namespace CuttingRoom.VariableSystem.Variables
{
	public class StringVariable : Variable
	{
		public string Value { get => value; }
        public string defaultValue = string.Empty;

        [InspectorVisible]
        [SerializeField]
        private string value = string.Empty;

        public void Start()
        {
            value = defaultValue;
        }

        public void Set(string newValue)
		{
			value = newValue;

#if UNITY_EDITOR
            defaultValue = value;
#endif

            RegisterVariableSet();
        }
        public override void SetValue(object newValue)
        {
            if (Value.GetType() == newValue.GetType())
            {
                Set((string)newValue);
            }
        }

        public override string GetValueAsString()
		{
			return Value;
		}

		public override void SetValueFromString(string newValue)
		{
			Set(newValue);
        }

        public override bool ValueEqual(object val)
        {
            if (Value.GetType() == val.GetType())
            {
                string typedVal = (string)val;
                return Value.Equals(typedVal);
            }
            else if (typeof(Variable).IsAssignableFrom(val.GetType()))
            {
                Variable var = val as Variable;
                return var.ValueEqual(Value);
            }
            return false;
        }
    }
}