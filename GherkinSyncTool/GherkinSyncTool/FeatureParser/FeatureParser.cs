﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Gherkin;
using Gherkin.Ast;
using GherkinSyncTool.Interfaces;
using GherkinSyncTool.Models;
using NLog;

namespace GherkinSyncTool.FeatureParser
{
    public class FeatureParser
    {
        private static readonly Logger Log = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType?.Name);
        public List<IFeatureFile> Parse(IEnumerable<string> gherkinFilePaths)
        {
            List<IFeatureFile> featureFiles = new List<IFeatureFile>();
            foreach (var gherkinFilePath in gherkinFilePaths)
            {
                FeatureFile file = new FeatureFile
                {
                    Document = ParseFeatureFile(gherkinFilePath),
                    RelativePath = gherkinFilePath
                };

                featureFiles.Add(file);
            }

            return featureFiles;
        }

        private static GherkinDocument ParseFeatureFile(string gherkinFilePath)
        {
            var parser = new Parser();
            try
            {
                return parser.Parse(gherkinFilePath);
            }
            catch (Exception)
            {
                Log.Fatal($"The file has not been parsed: {gherkinFilePath}");
                throw;
            }
        }
    }
}