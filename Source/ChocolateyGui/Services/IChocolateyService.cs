﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Chocolatey" file="IChocolateyService.cs">
//   Copyright 2014 - Present Rob Reynolds, the maintainers of Chocolatey, and RealDimensions Software, LLC
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ChocolateyGui.Services
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Management.Automation;
    using System.Threading.Tasks;
    using ChocolateyGui.Models;
    using ChocolateyGui.ViewModels.Items;

    public interface IChocolateyService
    {
        event PackagesChangedEventHandler PackagesUpdated;

        Task<bool> ExecutePackageCommand(Dictionary<string, object> commandArgs, bool refreshPackages = true);

        Task<IEnumerable<IPackageViewModel>> GetInstalledPackages(bool force = false);

        Task<IEnumerable<IPackageViewModel>> GetPackagesFromLocalDirectory(Dictionary<string, string> requestedPackages, string directoryPath);

        Task InstallPackage(string id, SemanticVersion version = null, Uri source = null);

        bool IsPackageInstalled(string id, SemanticVersion version);

        Task RunDirectChocolateyCommand(Dictionary<string, object> commandArgs, bool refreshPackages = true, bool logOutput = true);

        Task<Collection<PSObject>> RunIndirectChocolateyCommand(string command, bool refreshPackages = true, bool logOutput = true);

        Task UninstallPackage(string id, SemanticVersion version, bool force = false);

        Task UpdatePackage(string id, Uri source = null);
    }
}