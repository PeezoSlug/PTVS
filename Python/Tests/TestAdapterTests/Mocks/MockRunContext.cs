// Python Tools for Visual Studio
// Copyright(c) Microsoft Corporation
// All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the License); you may not use
// this file except in compliance with the License. You may obtain a copy of the
// License at http://www.apache.org/licenses/LICENSE-2.0
//
// THIS CODE IS PROVIDED ON AN  *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS
// OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY
// IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABILITY OR NON-INFRINGEMENT.
//
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.

namespace TestAdapterTests.Mocks
{
	class MockRunContext : IRunContext
	{
		public MockRunContext(IRunSettings runSettings, IReadOnlyList<TestCase> testCases, string resultsDirectory)
		{
			RunSettings = runSettings;
			TestCases = testCases;
			TestRunDirectory = resultsDirectory;
		}

		public IReadOnlyList<TestCase> TestCases { get; }

		public ITestCaseFilterExpression GetTestCaseFilter(IEnumerable<string> supportedProperties, Func<string, TestProperty> propertyProvider)
		{
			throw new NotImplementedException();
		}

		public bool InIsolation => throw new NotImplementedException();

		public bool IsBeingDebugged => false;

		public bool IsDataCollectionEnabled => throw new NotImplementedException();

		public bool KeepAlive => throw new NotImplementedException();

		public string SolutionDirectory => throw new NotImplementedException();

		public string TestRunDirectory { get; }

		public IRunSettings RunSettings { get; }
	}
}
