﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using KSP;
using KSPAchievements;

namespace ContractConfigurator
{
    /// <summary>
    /// ContractRequirement to provide requirement for player having performed done a fly by of a specific CelestialBody.
    /// </summary>
    public class FlyByRequirement : ProgressCelestialBodyRequirement
    {
        protected override ProgressNode GetTypeSpecificProgressNode(CelestialBodySubtree celestialBodySubtree)
        {
            return celestialBodySubtree.flyBy;
        }

        public override bool RequirementMet(ConfiguredContract contract)
        {
            return base.RequirementMet(contract) &&
                GetCelestialBodySubtree().IsComplete;
        }


        protected override string RequirementText()
        {
            string output = "Must " + (invertRequirement ? "not " : "") + "have performed " + ACheckTypeString() + "flyby of " + (targetBody == null ? "the target body" : targetBody.CleanDisplayName(true));

            return output;
        }
    }
}
