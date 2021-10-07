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

namespace Microsoft.PythonTools.Debugger
{
	internal class PythonModule
	{
		public PythonModule(int moduleId, string filename, string moduleName, bool isUserCode)
		{
			ModuleId = moduleId;
			Filename = filename;
			ModuleName = moduleName;
			IsUserCode = isUserCode;
		}

		public int ModuleId { get; }
		public string Filename { get; }
		public string ModuleName { get; }
		public bool IsUserCode { get; }

		public string Name
		{
			get
			{
				if (!string.IsNullOrEmpty(ModuleName))
				{
					return ModuleName;
				}

				if (PathUtils.IsValidPath(Filename))
				{
					return Path.GetFileNameWithoutExtension(Filename);
				}
				return Filename;
			}
		}

	}
}
