// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Security;
using Microsoft.Win32;
using NuGet.Common;

namespace NuGet.CommandLine
{
    public static class RegistryKeyUtility
    {
        public static RegistryKey OpenSubKey(string name, RegistryKey registryKey, ILogger logger)
        {
            try
            {
                var key = registryKey?.OpenSubKey(name);

                if (key != null)
                {
                    return key;
                }
            }
            catch (SecurityException ex)
            {
                // If the user doesn't have access to the registry, then we'll return null
                ExceptionUtilities.LogException(ex, logger);
            }

            return null;
        }

        public static object GetValue(string name, RegistryKey registryKey, ILogger logger)
        {
            try
            {
                return registryKey?.GetValue(name);
            }
            catch (SecurityException ex)
            {
                // If the user doesn't have access to the registry, then we'll return null
                ExceptionUtilities.LogException(ex, logger);
                return null;
            }
        }

        public static void Close(RegistryKey registryKey)
        {
            if (registryKey != null)
            {
                // Note that according to MSDN, this method does nothing if you call it on an instance of RegistryKey that is already closed.
                registryKey.Close();
            }
        }
    }
}
