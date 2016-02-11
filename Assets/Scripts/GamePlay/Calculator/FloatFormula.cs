using UnityEngine;
using System.Collections.Generic;
using Tools.ExpressionParser;

namespace Calculator {


	[System.SerializableAttribute]
	public class FloatFormula : AFormula {

		protected ExpressionDelegate ApplyFormula;

		public double GetResult ()
		{
			Debug.Assert(!isInitialized, "Calling GetFloatResult on a non-initialized formula on component " + parent.name);
			return ApplyFormula (this.PrepareParameterValueList());
		}

		public override void Initialize (MonoBehaviour _parent)
		{
			base.Initialize (_parent);

			ExpressionParser parser = new ExpressionParser ();
			Expression expression = parser.EvaluateExpression (FormulaText);
			ApplyFormula = expression.ToDelegate(parameters.ConvertAll<string> (t => t.alias).ToArray());
		}
	}
}