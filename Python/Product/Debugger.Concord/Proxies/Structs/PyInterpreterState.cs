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

namespace Microsoft.PythonTools.Debugger.Concord.Proxies.Structs
{
	[StructProxy(StructName = "_is")]
	internal class PyInterpreterState : StructProxy
	{
		private class Fields
		{
			public StructField<PointerProxy<PyInterpreterState>> next;
			public StructField<PointerProxy<PyThreadState>> tstate_head;
			public StructField<PointerProxy<PyDictObject>> modules;
			[FieldProxy(MinVersion = PythonLanguageVersion.V36)]
			public StructField<PointerProxy> eval_frame;
		}

		private readonly Fields _fields;

		public PyInterpreterState(DkmProcess process, ulong address)
			: base(process, address)
		{
			InitializeStruct(this, out _fields);
		}

		public static PyInterpreterState TryCreate(DkmProcess process, ulong address)
		{
			if (address == 0)
			{
				return null;
			}

			return new PyInterpreterState(process, address);
		}

		public PointerProxy<PyInterpreterState> next => GetFieldProxy(_fields.next);

		public PointerProxy<PyThreadState> tstate_head => GetFieldProxy(_fields.tstate_head);

		public PointerProxy<PyDictObject> modules => GetFieldProxy(_fields.modules);

		public PointerProxy eval_frame => GetFieldProxy(_fields.eval_frame);

		private class InterpHeadHolder : DkmDataItem
		{
			public readonly PointerProxy<PyInterpreterState> Proxy;

			public InterpHeadHolder(DkmProcess process)
			{
				PythonRuntimeInfo pyrtInfo = process.GetPythonRuntimeInfo();
				Proxy = pyrtInfo.GetRuntimeState()?.interpreters.head
					?? pyrtInfo.DLLs.Python.GetStaticVariable<PointerProxy<PyInterpreterState>>("interp_head");
			}
		}

		public static PointerProxy<PyInterpreterState> interp_head(DkmProcess process)
		{
			return process.GetOrCreateDataItem(() => new InterpHeadHolder(process)).Proxy;
		}

		public static IEnumerable<PyInterpreterState> GetInterpreterStates(DkmProcess process)
		{
			for (PyInterpreterState interp = interp_head(process).TryRead(); interp != null; interp = interp.next.TryRead())
			{
				yield return interp;
			}
		}

		public IEnumerable<PyThreadState> GetThreadStates()
		{
			for (PyThreadState tstate = tstate_head.TryRead(); tstate != null; tstate = tstate.next.TryRead())
			{
				yield return tstate;
			}
		}
	}
}
