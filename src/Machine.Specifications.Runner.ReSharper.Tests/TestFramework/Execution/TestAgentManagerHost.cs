﻿using JetBrains.Application.Components;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.TestRunner.Abstractions.Isolation;
using JetBrains.ReSharper.UnitTestFramework.Execution.TestRunner;
using Machine.Specifications.Runner.ReSharper.Runner;

namespace Machine.Specifications.Runner.ReSharper.Tests.TestFramework.Execution
{
    [SolutionComponent]
    public class TestAgentManagerHost : IAgentManagerHost, IHideImplementation<AgentManagerHost>
    {
        public TestAgentManagerHost(IAssemblyResolver assemblyResolver)
        {
            AgentManager = new AgentManager(assemblyResolver);
        }

        public ITestRunnerAgentManager AgentManager { get; }
    }
}
