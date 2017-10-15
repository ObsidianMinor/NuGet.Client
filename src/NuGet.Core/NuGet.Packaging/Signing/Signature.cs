// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace NuGet.Packaging.Signing
{
    /// <summary>
    /// Package signature information.
    /// </summary>
    public class Signature
    {
        /// <summary>
        /// Indicates if this is an author or repository signature.
        /// </summary>
        public SignatureType Type { get; set; }

        /// <summary>
        /// Signature friendly name.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Actual signature bytes.
        /// </summary>
        public byte[] Data { get; set; }

        /// <summary>
        /// Additional counter signatures.
        /// </summary>
        public IReadOnlyList<Signature> AdditionalSignatures { get; set; } = new List<Signature>();

        /// <summary>
        /// TEMPORARY - trust result to return.
        /// </summary>
        public SignatureVerificationStatus TestTrust { get; set; }
    }
}