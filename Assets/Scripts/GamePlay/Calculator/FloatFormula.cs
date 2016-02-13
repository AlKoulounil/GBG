using UnityEngine;
using System.Collections.Generic;
using Tools;
using Tools.ExpressionParser;

namespace Calculator {


	[System.SerializableAttribute]
	public class FloatFormula : AFormula {

		protected ExpressionDelegate ApplyFormula;

		public double GetResult ()
		{
			Debug.Assert(mIsInitialized, "Calling GetFloatResult on a non-initialized formula on component " 
				+ Error.Hierarchy(mParent.GetComponent()));
			return ApplyFormula (this.PrepareParameterValueList());
		}

		public override void Initialize (IFormulaParent _parent)
		{
			base.Initialize (_parent);

			ExpressionParser parser = new ExpressionParser ();
			Expression expression = parser.EvaluateExpression (mFormulaText);
			ApplyFormula = expression.ToDelegate(new List<string>(mParameters.Keys).ToArray());
		}
	}
}