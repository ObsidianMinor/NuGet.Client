// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Reflection;

namespace NuGet.PackageManagement
{
    public static class ExceptionUtility
    {
        public static Exception Unwrap(Exception exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException(nameof(exception));
            }

            while (exception.InnerException != null)
            {
                exception = exception.InnerException;
            }

            return exception;
        }
    }
}
