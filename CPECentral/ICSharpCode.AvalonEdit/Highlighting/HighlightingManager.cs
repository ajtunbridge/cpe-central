#region Using directives

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Xml;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using ICSharpCode.AvalonEdit.Utils;

#endregion

namespace ICSharpCode.AvalonEdit.Highlighting
{
    /// <summary>
    ///     Manages a list of syntax highlighting definitions.
    /// </summary>
    /// <remarks>
    ///     All memers on this class (including instance members) are thread-safe.
    /// </remarks>
    public class HighlightingManager : IHighlightingDefinitionReferenceResolver
    {
        private readonly List<IHighlightingDefinition> allHighlightings = new List<IHighlightingDefinition>();

        private readonly Dictionary<string, IHighlightingDefinition> highlightingsByExtension =
            new Dictionary<string, IHighlightingDefinition>(StringComparer.OrdinalIgnoreCase);

        private readonly Dictionary<string, IHighlightingDefinition> highlightingsByName =
            new Dictionary<string, IHighlightingDefinition>();

        private readonly object lockObj = new object();

        /// <summary>
        ///     Gets a copy of all highlightings.
        /// </summary>
        public ReadOnlyCollection<IHighlightingDefinition> HighlightingDefinitions
        {
            get
            {
                lock (lockObj) {
                    return Array.AsReadOnly(allHighlightings.ToArray());
                }
            }
        }

        /// <summary>
        ///     Gets the names of the registered highlightings.
        /// </summary>
        [Obsolete("Use the HighlightingDefinitions property instead.")]
        public IEnumerable<string> HighlightingNames
        {
            get
            {
                lock (lockObj) {
                    return new List<string>(highlightingsByName.Keys);
                }
            }
        }

        /// <summary>
        ///     Gets the default HighlightingManager instance.
        ///     The default HighlightingManager comes with built-in highlightings.
        /// </summary>
        public static HighlightingManager Instance
        {
            get { return DefaultHighlightingManager.Instance; }
        }

        #region IHighlightingDefinitionReferenceResolver Members

        /// <summary>
        ///     Gets a highlighting definition by name.
        ///     Returns null if the definition is not found.
        /// </summary>
        public IHighlightingDefinition GetDefinition(string name)
        {
            lock (lockObj) {
                IHighlightingDefinition rh;
                if (highlightingsByName.TryGetValue(name, out rh)) {
                    return rh;
                }
                return null;
            }
        }

        #endregion

        /// <summary>
        ///     Gets a highlighting definition by extension.
        ///     Returns null if the definition is not found.
        /// </summary>
        public IHighlightingDefinition GetDefinitionByExtension(string extension)
        {
            lock (lockObj) {
                IHighlightingDefinition rh;
                if (highlightingsByExtension.TryGetValue(extension, out rh)) {
                    return rh;
                }
                return null;
            }
        }

        /// <summary>
        ///     Registers a highlighting definition.
        /// </summary>
        /// <param name="name">The name to register the definition with.</param>
        /// <param name="extensions">The file extensions to register the definition for.</param>
        /// <param name="highlighting">The highlighting definition.</param>
        public void RegisterHighlighting(string name, string[] extensions, IHighlightingDefinition highlighting)
        {
            if (highlighting == null) {
                throw new ArgumentNullException("highlighting");
            }

            lock (lockObj) {
                allHighlightings.Add(highlighting);
                if (name != null) {
                    highlightingsByName[name] = highlighting;
                }
                if (extensions != null) {
                    foreach (string ext in extensions) {
                        highlightingsByExtension[ext] = highlighting;
                    }
                }
            }
        }

        /// <summary>
        ///     Registers a highlighting definition.
        /// </summary>
        /// <param name="name">The name to register the definition with.</param>
        /// <param name="extensions">The file extensions to register the definition for.</param>
        /// <param name="lazyLoadedHighlighting">A function that loads the highlighting definition.</param>
        public void RegisterHighlighting(string name, string[] extensions,
            Func<IHighlightingDefinition> lazyLoadedHighlighting)
        {
            if (lazyLoadedHighlighting == null) {
                throw new ArgumentNullException("lazyLoadedHighlighting");
            }
            RegisterHighlighting(name, extensions, new DelayLoadedHighlightingDefinition(name, lazyLoadedHighlighting));
        }

        #region Nested type: DefaultHighlightingManager

        internal sealed class DefaultHighlightingManager : HighlightingManager
        {
            public new static readonly DefaultHighlightingManager Instance = new DefaultHighlightingManager();

            public DefaultHighlightingManager()
            {
                Resources.RegisterBuiltInHighlightings(this);
            }

            // Registering a built-in highlighting
            internal void RegisterHighlighting(string name, string[] extensions, string resourceName)
            {
                try {
#if DEBUG
                    // don't use lazy-loading in debug builds, show errors immediately
                    XshdSyntaxDefinition xshd;
                    using (Stream s = Resources.OpenStream(resourceName)) {
                        using (var reader = new XmlTextReader(s)) {
                            xshd = HighlightingLoader.LoadXshd(reader, false);
                        }
                    }
                    Debug.Assert(name == xshd.Name);
                    if (extensions != null) {
                        Debug.Assert(Enumerable.SequenceEqual(extensions, xshd.Extensions));
                    }
                    else {
                        Debug.Assert(xshd.Extensions.Count == 0);
                    }

                    // round-trip xshd:
//					string resourceFileName = Path.Combine(Path.GetTempPath(), resourceName);
//					using (XmlTextWriter writer = new XmlTextWriter(resourceFileName, System.Text.Encoding.UTF8)) {
//						writer.Formatting = Formatting.Indented;
//						new Xshd.SaveXshdVisitor(writer).WriteDefinition(xshd);
//					}
//					using (FileStream fs = File.Create(resourceFileName + ".bin")) {
//						new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter().Serialize(fs, xshd);
//					}
//					using (FileStream fs = File.Create(resourceFileName + ".compiled")) {
//						new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter().Serialize(fs, Xshd.HighlightingLoader.Load(xshd, this));
//					}

                    RegisterHighlighting(name, extensions, HighlightingLoader.Load(xshd, this));
#else
					RegisterHighlighting(name, extensions, LoadHighlighting(resourceName));
					#endif
                }
                catch (HighlightingDefinitionInvalidException ex) {
                    throw new InvalidOperationException("The built-in highlighting '" + name + "' is invalid.", ex);
                }
            }

            [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
                Justification = "LoadHighlighting is used only in release builds")]
            private Func<IHighlightingDefinition> LoadHighlighting(string resourceName)
            {
                Func<IHighlightingDefinition> func = delegate {
                    XshdSyntaxDefinition xshd;
                    using (Stream s = Resources.OpenStream(resourceName)) {
                        using (var reader = new XmlTextReader(s)) {
                            // in release builds, skip validating the built-in highlightings
                            xshd = HighlightingLoader.LoadXshd(reader, true);
                        }
                    }
                    return HighlightingLoader.Load(xshd, this);
                };
                return func;
            }
        }

        #endregion

        #region Nested type: DelayLoadedHighlightingDefinition

        private sealed class DelayLoadedHighlightingDefinition : IHighlightingDefinition2
        {
            private readonly object lockObj = new object();
            private readonly string name;
            private IHighlightingDefinition definition;
            private Func<IHighlightingDefinition> lazyLoadingFunction;
            private Exception storedException;

            public DelayLoadedHighlightingDefinition(string name, Func<IHighlightingDefinition> lazyLoadingFunction)
            {
                this.name = name;
                this.lazyLoadingFunction = lazyLoadingFunction;
            }

            #region IHighlightingDefinition2 Members

            public string Name
            {
                get
                {
                    if (name != null) {
                        return name;
                    }
                    return GetDefinition().Name;
                }
            }

            public HighlightingRuleSet MainRuleSet
            {
                get { return GetDefinition().MainRuleSet; }
            }

            public HighlightingRuleSet GetNamedRuleSet(string name)
            {
                return GetDefinition().GetNamedRuleSet(name);
            }

            public HighlightingColor GetNamedColor(string name)
            {
                return GetDefinition().GetNamedColor(name);
            }

            public IEnumerable<HighlightingColor> NamedHighlightingColors
            {
                get { return GetDefinition().NamedHighlightingColors; }
            }

            public IDictionary<string, string> Properties
            {
                get
                {
                    var def = GetDefinition() as IHighlightingDefinition2;
                    if (def != null) {
                        return def.Properties;
                    }
                    return null;
                }
            }

            #endregion

            [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes",
                Justification = "The exception will be rethrown")]
            private IHighlightingDefinition GetDefinition()
            {
                Func<IHighlightingDefinition> func;
                lock (lockObj) {
                    if (definition != null) {
                        return definition;
                    }
                    func = lazyLoadingFunction;
                }
                Exception exception = null;
                IHighlightingDefinition def = null;
                try {
                    using (BusyManager.BusyLock busyLock = BusyManager.Enter(this)) {
                        if (!busyLock.Success) {
                            throw new InvalidOperationException(
                                "Tried to create delay-loaded highlighting definition recursively. Make sure the are no cyclic references between the highlighting definitions.");
                        }
                        def = func();
                    }
                    if (def == null) {
                        throw new InvalidOperationException(
                            "Function for delay-loading highlighting definition returned null");
                    }
                }
                catch (Exception ex) {
                    exception = ex;
                }
                lock (lockObj) {
                    lazyLoadingFunction = null;
                    if (definition == null && storedException == null) {
                        definition = def;
                        storedException = exception;
                    }
                    if (storedException != null) {
                        throw new HighlightingDefinitionInvalidException("Error delay-loading highlighting definition",
                            storedException);
                    }
                    return definition;
                }
            }

            public override string ToString()
            {
                return Name;
            }
        }

        #endregion
    }
}