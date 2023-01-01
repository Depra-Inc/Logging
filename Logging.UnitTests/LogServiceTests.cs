// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using Depra.Logging.Enums;
using Depra.Logging.Processors;
using Depra.Logging.Services;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace Logging.UnitTests
{
    [TestFixture(TestOf = typeof(LogService))]
    internal sealed class LogServiceTests
    {
        private LogService _logService;
        
        [SetUp]
        public void Setup()
        {
            var logProcessor = new ConsoleLogProcessor();
                ///Substitute.For<ILogProcessor>();
            _logService = new LogService(logProcessor);
        }

        [Test]
        public void WhenLoggingInfo_AndWithoutArgs_ThenNoExceptionIsThrown()
        {
            // Act.
            Action act = () => _logService.Info();
            
            // Assert.
            act.Should().NotThrow();
        }

        [Test]
        public void WhenLoggingInfo_AndWithArgs_ThenNoExceptionIsThrown()
        {
            // Arrange.
            var args = new object[] { 1, nameof(WhenLoggingInfo_AndWithArgs_ThenNoExceptionIsThrown) };
            
            // Act.
            Action act = () => _logService.Info(args);

            act.Should().NotThrow();
        }

        [Test]
        public void WhenLoggingWarning_AndWithoutArgs_ThenNoExceptionIsThrown()
        {
            // Act.
            Action act = () => _logService.Warning();
            
            // Assert.
            act.Should().NotThrow();
        }
        
        [Test]
        public void WhenLoggingWarning_AndWithArgs_ThenNoExceptionIsThrown()
        {
            // Arrange.
            var args = new object[] { 1, nameof(WhenLoggingWarning_AndWithArgs_ThenNoExceptionIsThrown) };
            
            // Act.
            Action act = () => _logService.Warning(args);

            act.Should().NotThrow();
        }
        
        [Test]
        public void WhenLoggingAssert_AndWithoutArgs_ThenNoExceptionIsThrown()
        {
            // Act.
            Action act = () => _logService.Assert();
            
            // Assert.
            act.Should().NotThrow();
        }
        
        [Test]
        public void WhenLoggingAssert_AndWithArgs_ThenNoExceptionIsThrown()
        {
            // Arrange.
            var args = new object[] { 1, nameof(WhenLoggingAssert_AndWithArgs_ThenNoExceptionIsThrown) };
            
            // Act.
            Action act = () => _logService.Assert(args);

            act.Should().NotThrow();
        }
        
        [Test]
        public void WhenLoggingException_AndWithoutArgs_ThenNoExceptionIsThrown()
        {
            // Act.
            Action act = () => _logService.Exception();
            
            // Assert.
            act.Should().NotThrow();
        }
        
        [Test]
        public void WhenLoggingException_AndWithArgs_ThenNoExceptionIsThrown()
        {
            // Arrange.
            var args = new object[] { 1, nameof(WhenLoggingException_AndWithArgs_ThenNoExceptionIsThrown) };
            
            // Act.
            Action act = () => _logService.Exception(args);

            act.Should().NotThrow();
        }

        [Test]
        public void WhenLoggingCustomInfo_AndArgsLikeAnException_ThenNoExceptionIsThrown()
        {
            // Arrange.
            const LogType logType = LogType.Exception;
            const Priority priority = Priority.FatalError;
            var args = new object[] { 1, nameof(WhenLoggingCustomInfo_AndArgsLikeAnException_ThenNoExceptionIsThrown) };
            
            // Act.
            Action act = () => _logService.Custom(logType, priority, args);

            act.Should().NotThrow();
        }
    }
}