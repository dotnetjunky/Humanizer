using Humanizer.DateTimeHumanizeStrategy;
using Humanizer.Localisation.Formatters;
using Humanizer.Localisation.NumberToWords;
using Humanizer.Localisation.Ordinalizers;

namespace Humanizer.Configuration
{
    /// <summary>
    /// Provides a configuration point for Humanizer
    /// </summary>
    public static class Configurator
    {
        private static readonly LocaliserRegistry<IFormatter> _formatters = new FormatterRegistry();
        /// <summary>
        /// A registry of formatters used to format strings based on the current locale
        /// </summary>
        public static LocaliserRegistry<IFormatter> Formatters
        {
            get { return _formatters; }
        }

        private static readonly LocaliserRegistry<INumberToWordsConverter> _numberToWordsConverters = new NumberToWordsConverterRegistry();
        /// <summary>
        /// A registry of number to words converters used to localise ToWords and ToOrdinalWords methods
        /// </summary>
        public static LocaliserRegistry<INumberToWordsConverter> NumberToWordsConverters
        {
            get { return _numberToWordsConverters; }
        }

        private static readonly LocaliserRegistry<IOrdinalizer> _ordinalizers = new OrdinalizerRegistry();
        /// <summary>
        /// A registry of ordinalizers used to localise Ordinalize method
        /// </summary>
        public static LocaliserRegistry<IOrdinalizer> Ordinalizers
        {
            get { return _ordinalizers; }
        }
        
        /// <summary>
        /// The formatter to be used
        /// </summary>
        internal static IFormatter Formatter
        {
            get
            {
                return Formatters.ResolveForUiCulture();
            }
        }

        /// <summary>
        /// The converter to be used
        /// </summary>
        internal static INumberToWordsConverter NumberToWordsConverter
        {
            get
            {
                return NumberToWordsConverters.ResolveForUiCulture();
            }
        }

        /// <summary>
        /// The ordinalizer to be used
        /// </summary>
        internal static IOrdinalizer Ordinalizer
        {
            get
            {
                return Ordinalizers.ResolveForUiCulture();
            }
        }

        private static IDateTimeHumanizeStrategy _dateTimeHumanizeStrategy = new DefaultDateTimeHumanizeStrategy();
        /// <summary>
        /// The strategy to be used for DateTime.Humanize
        /// </summary>
        public static IDateTimeHumanizeStrategy DateTimeHumanizeStrategy
        {
            get { return _dateTimeHumanizeStrategy; }
            set { _dateTimeHumanizeStrategy = value; }
        }
    }
}
