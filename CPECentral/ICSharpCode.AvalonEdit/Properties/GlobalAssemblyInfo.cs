﻿#region Using directives

using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;

#endregion

[assembly: ComVisible(false)]
[assembly: AssemblyCompany("ic#code")]
[assembly: AssemblyProduct("SharpDevelop")]
[assembly: AssemblyCopyright("2000-2013 AlphaSierraPapa for the SharpDevelop Team")]
[assembly:
    AssemblyVersion(
        RevisionClass.Major + "." + RevisionClass.Minor + "." + RevisionClass.Build + "." + RevisionClass.Revision)]
[assembly: AssemblyInformationalVersion(RevisionClass.FullVersion + "-8e799bf3")]
[assembly: NeutralResourcesLanguage("en-US")]
[assembly: SuppressMessage("Microsoft.Usage", "CA2243:AttributeStringLiteralsShouldParseCorrectly",
    Justification = "AssemblyInformationalVersion does not need to be a parsable version")]

internal static class RevisionClass
{
    public const string Major = "4";
    public const string Minor = "3";
    public const string Build = "1";
    public const string Revision = "9429";

    public const string VersionName = null;
        // "" is not valid for no version name, you have to use null if you don't want a version name (eg "Beta 1")

    public const string FullVersion = Major + "." + Minor + "." + Build + ".9429";
}