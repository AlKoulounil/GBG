using UnityEngine;
using System;
using System.Collections.Generic;
using Beings;
using Calculator;
using Tools;
using Values;


namespace Effects
{
	public class Transformation : AEffect, IHasFormula
	{
		public const float MAX_QUANTITY = -1;

		public float MaxQuantityPerRun = 1;

		[System.SerializableAttribute]
		public class InOutVariable : IFormulaParent
		{
			public string VariableName;
			public string QuantityFormula;
			public BEING_KEY Destination;

			protected FloatFormula mFormula;
			protected Transformation mParent;
			protected bool mIsOutput;

			public bool IsOutput {
				get {
					return mIsOutput;
				}
				set {
					mIsOutput = value;
				}
			}

			public FloatFormula Formula {
				get {
					return mFormula;
				}
				set {
					mFormula = value;
				}
			}

			/// <summary>
			/// Helps multiplying by -1 the quantity of variable if is consumed and by +1 if it is produced
			/// </summary>
			/// <value>-1 if input or +1 if output</value>
			public double OutputFactor {
				get {
					if(mIsOutput) {
						return 1;
					} else {
						return -1;
					}
				}
			}


			public void SetParent (Transformation _parent)
			{
				mParent = _parent;
			}

			public Component GetComponent ()
			{
				return mParent;
			}

			public string GetFormulaText ()
			{
				return QuantityFormula;
			}
		}

		public InOutVariable[] Inputs;
		public InOutVariable[] Outputs;
		protected List<InOutVariable> mInOuts;
		protected bool mIsInitialized;
		protected ABeing mSelfBeing;

		public void Initialize ()
		{
			if (mIsInitialized) {
				return;
			}

			mInOuts = new List<InOutVariable> ();

			foreach (InOutVariable input in Inputs) {
				input.IsOutput = false;
				mInOuts.Add (input);
			}

			foreach (InOutVariable output in Outputs) {
				output.IsOutput = true;
				mInOuts.Add (output);
			}

			Debug.Assert (mInOuts.Count >= 1, "Transformation " + Error.Hierarchy (this) + " has no input nor outputs."); 

			foreach (InOutVariable v in mInOuts) {
				v.SetParent (this);

				v.Formula = new FloatFormula ();
				v.Formula.Initialize (v);

				Debug.Assert (v.Destination == BEING_KEY.SELF || v.Destination == BEING_KEY.TARGET,
					"Error initializing Transformation " + Error.Hierarchy (this) 
					+ ". Only self and target destinations are allowed.");
			}


			
			mIsInitialized = true;
		}

		public bool HasSelfBeing ()
		{
			Debug.Assert (mIsInitialized, "Calling HasSelfBeing on Transformation " + Error.Hierarchy (this)
			+ " while it is not yet initialized"); 
			return mInOuts [0].Formula.HasSelfBeing ();
		}

		public void SetSelfBeing (ABeing _self)
		{
			Debug.Assert (mIsInitialized, "Calling SetSelfBeing on Transformation " + Error.Hierarchy (this)
			+ " while it is not yet initialized");
			mSelfBeing = _self;

			foreach (InOutVariable v in mInOuts) {
				v.Formula.SetSelfBeing (_self);
			}
		}

		public void SetTargetBeing (ABeing _target)
		{
			Debug.Assert (mIsInitialized, "Calling SetTargetBeing on Transformation " + Error.Hierarchy (this)
			+ " while it is not yet initialized"); 
			foreach (InOutVariable v in mInOuts) {
				v.Formula.SetSelfBeing (_target);
			}
		}

		public override void Apply (ABeing target)
		{
			this.SetTargetBeing (target);

			Dictionary<string, double> quantities = new Dictionary<string, double>();
			Dictionary<BEING_KEY, ABeing> destinations = new Dictionary<BEING_KEY, ABeing>();
			destinations.Add (BEING_KEY.SELF, mSelfBeing);
			destinations.Add (BEING_KEY.TARGET, target);
			double quantityForThisRun = MaxQuantityPerRun;

			foreach (InOutVariable v in mInOuts) {
				Variable var =  destinations[v.Destination].GetVariable (v.VariableName);

				// Compute quantity according to formula
				quantities.Add(v.VariableName, v.Formula.GetResult());

				if (!v.IsOutput) {
					//Computes the maximum amount of each ressource we can consume.
					quantityForThisRun = Math.Min (var.GetValue () / quantities [v.VariableName], quantityForThisRun);
				}
			}

			foreach (InOutVariable v in mInOuts) {
				Variable var =  destinations[v.Destination].GetVariable (v.VariableName);

				//Adjust quantity according to amount consumed or produced
				var.SetValue (var.GetValue () + quantityForThisRun * v.OutputFactor * quantities [v.VariableName]);
			}

			this.SetTargetBeing (null);
		}

	}
}
