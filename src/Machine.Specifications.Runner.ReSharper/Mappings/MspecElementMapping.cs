﻿using JetBrains.ReSharper.TestRunner.Abstractions.Objects;
using JetBrains.ReSharper.UnitTestFramework.Elements;
using JetBrains.ReSharper.UnitTestFramework.Execution.TestRunner;
using JetBrains.ReSharper.UnitTestFramework.Exploration;

namespace Machine.Specifications.Runner.ReSharper.Mappings
{
    public abstract class MspecElementMapping<TElement, TTask> : IUnitTestElementToRemoteTaskMapping<TElement>, IRemoteTaskToUnitTestElementMapping<TTask>
        where TElement : IUnitTestElement
        where TTask : RemoteTask
    {
        protected MspecElementMapping(MspecServiceProvider services)
        {
            Services = services;
        }

        protected MspecServiceProvider Services { get; }

        protected abstract TTask ToRemoteTask(TElement element, ITestRunnerExecutionContext context);

        protected abstract TElement? ToElement(TTask task, ITestRunnerDiscoveryContext context, IUnitTestElementObserver observer);

        public RemoteTask GetRemoteTask(TElement element, ITestRunnerExecutionContext context)
        {
            return ToRemoteTask(element, context);
        }

        public IUnitTestElement? GetElement(TTask task, ITestRunnerDiscoveryContext context, IUnitTestElementObserver observer)
        {
            return ToElement(task, context, observer);
        }

        protected UnitTestElementFactory GetFactory(ITestRunnerDiscoveryContext context)
        {
            return context.GetOrCreateDataUnderLock(
                MspecElementMappingKeys.ElementFactoryKey, static () => new UnitTestElementFactory());
        }
    }
}
