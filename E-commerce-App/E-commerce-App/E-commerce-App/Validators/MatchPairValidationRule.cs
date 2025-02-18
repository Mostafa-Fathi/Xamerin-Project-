﻿using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce_App.Validators
{

	public class MatchPairValidationRule<T> : IValidationRule<ValidatablePair<T>>
	{
		public string ValidationMessage { get; set; }

		public bool Check(ValidatablePair<T> value)
		{
			return value.Item1.Value.Equals(value.Item2.Value);
		}
	}
}
