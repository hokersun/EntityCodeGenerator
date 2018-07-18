﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.
namespace Microsoft.DbContextPackage.Utilities
{
    using System.Diagnostics;
    using System.IO;
    using System.Text;

    internal static class Templates
    {
        public const string ContextTemplate = @"CodeTemplates\ReverseEngineerCodeFirst\Context.tt";
        public const string EntityTemplate = @"CodeTemplates\ReverseEngineerCodeFirst\Entity.tt";
        public const string MappingTemplate = @"CodeTemplates\ReverseEngineerCodeFirst\Mapping.tt";
        public const string RepositoryTemplate = @"CodeTemplates\ReverseEngineerCodeFirst\Repository.tt";
        public const string ServiceTemplate = @"CodeTemplates\ReverseEngineerCodeFirst\Service.tt";
        public const string SvcTemplate = @"CodeTemplates\ReverseEngineerCodeFirst\Svc.tt";


        public static string GetDefaultTemplate(string path)
        {

            var stream = typeof(Templates).Assembly.GetManifestResourceStream(
                "Microsoft.DbContextPackage." + path.Replace('\\', '.'));
            Debug.Assert(stream != null);

            using (var reader = new StreamReader(stream, Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
