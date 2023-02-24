using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CuttingRoom;
using CuttingRoom.VariableSystem.Constraints;

public static class ConstraintProcessor
{
	public static List<NarrativeObject> Process(NarrativeSpace narrativeSpace, List<NarrativeObject> candidates, List<Constraint> constraints)
	{
		// All candidates are an option to begin with.
		List<NarrativeObject> candidatesMatchingConstraints = new List<NarrativeObject>(candidates);

		// Iterate candidates and check them against decision point constraints.
		for (int candidateCount = candidatesMatchingConstraints.Count - 1; candidateCount >= 0; candidateCount--)
		{
			NarrativeObject candidate = candidatesMatchingConstraints[candidateCount];

			// For each constraint.
			for (int constraintCount = 0; constraintCount < constraints.Count; constraintCount++)
			{
				Constraint constraint = constraints[constraintCount];

				if (!constraint.Evaluate(narrativeSpace, candidate))
				{
					candidatesMatchingConstraints.Remove(candidate);
				}
			}
		}

		for (int candidateCount = candidatesMatchingConstraints.Count - 1; candidateCount >= 0; candidateCount--)
		{
			NarrativeObject candidate = candidatesMatchingConstraints[candidateCount];

			// For each constraint on the candidate.
			for (int candidateConstraintCount = 0; candidateConstraintCount < candidate.constraints.Count; candidateConstraintCount++)
			{
				Constraint candidateConstraint = candidate.constraints[candidateConstraintCount];

				if (!candidateConstraint.Evaluate(narrativeSpace, candidate))
				{
					candidatesMatchingConstraints.Remove(candidate);
				}
			}
		}

		return candidatesMatchingConstraints;
	}
}
