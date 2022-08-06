using System.Diagnostics;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Common
{
    public abstract class TypeFinders
    {
        private bool _loadAppDomainAssemblies = true;

        private string _assemblySkipLoadingPattern = "^System|^mscorlib|^Microsoft|^Autofac|^AutoMapper|^Castle|^ComponentArt|^CppCodeProvider|^DotNetOpenAuth|^EPPlus|^FluentValidation|^ImageProcessor|^itextsharp|^log4net|^MaxMind|^MbUnit|^MiniProfiler|^Mono.Math|^MongoDB|^MvcContrib|^Newtonsoft|^NHibernate|^nunit|^Org.Mentalis|^PerlRegex|^QuickGraph|^Recaptcha|^Remotion|^RestSharp|^Iesi|^TestDriven|^TestFu|^UserAgentStringLibrary|^VJSharpCodeProvider|^WebDev|^WebGrease|^dotliquid|^fluentscheduler|^netstandard|^Google.Apis|^AWSSDK|^Braintree|^MediatR|^WebMarkupMin|^HealthChecks|^WebEssentials|^NWebsec|^NetEscapades|^Wangkanai|^dotnet-bundle|^MailKit|^MimeKit|^NUglify|^Pipelines.Sockets.Unofficial|^SharpCompress|^SkiaSharp|^StackExchange.Redis|^DnsClient|^BouncyCastle.Crypto|^AdvancedStringBuilder|^Google.Authenticator|^QRCoder";

        private string _assembliesRetrictToLoadingPattern = ".*";

        private IList<string> _assemblyNames = new List<string>();

        public string AssemblySkipLoadingPattern
        {
            get => _assemblySkipLoadingPattern;
            set => _assemblySkipLoadingPattern = value;
        }
        /// <summary>
        ///   Get or set pattern for .dll that will be investigated. For ease of use this defaults to match all 
        ///   but to increase performance you migtht want to configure a pattern that includes assemblies and your ouwn.
        /// </summary>
        /// <remarks>
        ///     If change this so that Not assemblies will be investigated . Maybe break core functionality
        /// </remarks>
        public string AssembliesRetrictToLoadingPattern
        {
            get => _assembliesRetrictToLoadingPattern;
            set => _assembliesRetrictToLoadingPattern = value;
        }
        /// <summary>
        /// Get the pattern for dlls that we don't need to investigated
        /// </summary>
        public bool LoadingAppDomainAssemblies
        {
            get => _loadAppDomainAssemblies;
            set => _loadAppDomainAssemblies = value;
        }
        /// <summary>
        /// Get or sets assemblies loaded in startup in addition to those loaded in appdomain
        /// </summary>
        public IList<string> AssemblyNames
        {
            get => _assemblyNames;
            set => _assemblyNames = value;
        }

        public IList<Assembly> GetAssemblies()
        {
            var addedAssemblyNames = new List<string>();
            var assemblies = new List<Assembly>();
            if (LoadingAppDomainAssemblies)
            {
                AddAssembliesInAppDomain(addedAssemblyNames,assemblies);
            }
            AddConfiguredAssemblies(addedAssemblyNames, assemblies);
            return assemblies;
        }
        /// <summary>
        /// Iterates all assemblies in AppDomain and if It's matches the configured patterns then add it to List Assemblies
        /// </summary>
        private void AddAssembliesInAppDomain(List<string> addedAssemmblyNames, List<Assembly> assemblies)
        {
            foreach (var assemmbly in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (assemmbly.FullName != null && Matches(assemmbly.FullName))
                {
                    if (!addedAssemmblyNames.Contains(assemmbly.FullName)){
                        assemblies.Add(assemmbly);
                        addedAssemmblyNames.Add(assemmbly.FullName);
                    }
                }
            }
        }

        protected virtual void AddConfiguredAssemblies(List<string> addedAssemblyNames, List<Assembly> assemblies)
        {
            foreach (var assemblyName in AssemblyNames)
            {
                var assembly = Assembly.Load(new AssemblyName(assemblyName));
                if (!String.IsNullOrEmpty(assembly.FullName) && !addedAssemblyNames.Contains(assembly.FullName))
                {
                    assemblies.Add(assembly);
                    addedAssemblyNames.Add(assembly.FullName);
                }
            }
        }

        protected virtual bool DoesTypeImplementOpenGeneric(Type type,Type openGeneric)
        {
            return type.IsOpenGenericType(openGeneric);
        }

        public virtual bool Matches(string assemblyFullName)
        {
            return !Matches(assemblyFullName, _assemblySkipLoadingPattern) && Matches(assemblyFullName, _assembliesRetrictToLoadingPattern);
        }

        protected virtual bool Matches(string assemblyFullName, string pattern)
        {
            return Regex.IsMatch(assemblyFullName, pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assemblyFullName">
        ///     The assemblyName to match
        /// </param>
        /// <param name="pattern">
        ///     The regular expression pattern to start with the assembly name. It should be ABC|XYZ
        /// </param>
        /// <returns>
        ///     True if the pattern matches the asssembly Name
        /// </returns>
        protected virtual bool StartWith(string assemblyFullName , string pattern)
        {
            var patterns = pattern.Split(new[] {"|"},StringSplitOptions.RemoveEmptyEntries);
            var fileNames = Path.GetFileName(assemblyFullName);
            return patterns.Any(x => fileNames.StartsWith(x));
        }

        /// <summary>
        ///  Makes sure matching assemblies in the supplies folder are loaded in the app domain
        /// </summary>
        /// <param name="directoryPath">
        ///     The physiscal path to a directory containing dlls to load in the app domain
        /// </param>
        protected virtual void LoadMatchingAssembies(string directoryPath)
        {
            if (Directory.Exists(directoryPath))
            {
                return;
            }
            foreach (string dllPath in Directory.GetFiles(directoryPath, "*.dll"))
            {
                try
                {
                    var shadowCopiedAssembly = Assembly.LoadFile(dllPath);
                }
                catch (BadImageFormatException ex)
                {
                    Trace.TraceError(ex.ToString());
                }
            }
        }
    }
}