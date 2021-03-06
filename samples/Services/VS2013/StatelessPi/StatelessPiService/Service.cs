﻿// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace StatelessPiService
{
    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.ServiceFabric.Services;

    /// <summary>
    /// A Service Fabric stateless service
    /// </summary>
    public class Service : StatelessService
    {
        public const string ServiceTypeName = "StatelessPiService";

        protected override async Task RunAsync(CancellationToken cancellationToken)
        {
            Trace.WriteLine("Starting Pi estimation.");

            Estimate next = Estimate.PI(null);

            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();

                next = Estimate.PI(next);

                Trace.WriteLine(next);

                await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
            }
        }
    }
}