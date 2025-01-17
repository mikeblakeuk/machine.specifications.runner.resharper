﻿using System;
using JetBrains.ReSharper.TestRunner.Abstractions;
using JetBrains.ReSharper.TestRunner.Abstractions.Objects;

namespace Machine.Specifications.Runner.ReSharper.Tests.TestFramework.Execution
{
    public class TestExecutionSink : ITestExecutionSink
    {
        private readonly IMessageBroker broker;

        private readonly ILogger logger = Logger.GetLogger<TestExecutionSink>();

        public TestExecutionSink(IMessageBroker broker)
        {
            this.broker = broker;
        }

        public void TestStarting(RemoteTask task)
        {
            try
            {
                broker.TestStarting(task).Wait();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }

        public void TestDuration(RemoteTask task, TimeSpan duration)
        {
            try
            {
                broker.TestDuration(task, duration).Wait();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }

        public void TestException(RemoteTask task, ExceptionInfo[] exceptions)
        {
            try
            {
                broker.TestException(task, exceptions).Wait();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }

        public void TestFinished(RemoteTask task, string message, TestResult result)
        {
            try
            {
                broker.TestFinished(task, message, result).Wait();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }

        public void TestOutput(RemoteTask task, string text, TestOutputType outputType)
        {
            try
            {
                broker.TestOutput(task, text, outputType).Wait();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }

        public void DynamicTestDiscovered(RemoteTask task)
        {
            try
            {
                broker.DynamicTestDiscovered(task).Wait();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
    }
}
