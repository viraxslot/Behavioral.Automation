﻿using System.Collections.Generic;
using TestRail.Types;

namespace GherkinSyncTool.Synchronizers.TestRailSynchronizer.TestRailManager.Model
{
    public class TestRailSection : Section
    {
        public List<Case> FeatureFiles { get; set; } = new();
        public List<TestRailSection> ChildSections { get; set; } = new();

        public TestRailSection(Section section)
        {
            Id = section.Id;
            Depth = section.Depth;
            Description = section.Description;
            Name = section.Name;
            ParentId = section.ParentId;
            SuiteId = section.SuiteId;
            DisplayOrder = section.DisplayOrder;
        }

        public override bool Equals(object obj)
        {
            if (obj is not Section other) return false;
            return other.Name == Name;
        }
    }
}