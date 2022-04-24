﻿// Copyright(c) Microsoft Corporation
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

using System;
using System.Collections.Generic;
using System.IO;

namespace Microsoft.PythonTools.Common.Core.IO {
    public interface IFileSystem {
        IFileSystemWatcher CreateFileSystemWatcher(string directory, string filter);
        IDirectoryInfo GetDirectoryInfo(string directoryPath);
        bool FileExists(string fullPath);
        bool DirectoryExists(string fullPath);

        long FileSize(string path);

        FileAttributes GetFileAttributes(string fullPath);
        void SetFileAttributes(string fullPath, FileAttributes attributes);
        DateTime GetLastWriteTimeUtc(string fullPath);

        string ReadAllText(string path);
        void WriteAllText(string path, string content);

        IEnumerable<string> FileReadAllLines(string path);
        void FileWriteAllLines(string path, IEnumerable<string> contents);

        byte[] FileReadAllBytes(string path);
        void FileWriteAllBytes(string path, byte[] bytes);

        Stream CreateFile(string path);
        Stream FileOpen(string path, FileMode mode);
        Stream FileOpen(string path, FileMode mode, FileAccess access, FileShare share);

        Version GetFileVersion(string path);
        void DeleteFile(string path);
        void DeleteDirectory(string path, bool recursive);
        string[] GetFileSystemEntries(string path, string searchPattern, SearchOption options);
        void CreateDirectory(string path);

        string[] GetFiles(string path);
        string[] GetFiles(string path, string pattern);
        string[] GetFiles(string path, string pattern, SearchOption option);
        string[] GetDirectories(string path);

        bool IsPathUnderRoot(string root, string path);
        StringComparison StringComparison { get; }
    }
}
