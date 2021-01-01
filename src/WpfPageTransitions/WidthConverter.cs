// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WidthConverter.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The width converter class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WpfPageTransitions
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    /// <inheritdoc cref="IValueConverter"/>
    /// <summary>
    /// The width converter class.
    /// </summary>
    /// <seealso cref="IValueConverter"/>
    // ReSharper disable once UnusedMember.Global
    public class WidthConverter : IValueConverter
    {
        /// <inheritdoc cref="IValueConverter"/>
        /// <summary>
        /// Converts the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="targetType">The target type.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>A new <see cref="object"/>.</returns>
        /// <seealso cref="IValueConverter"/>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                return (double)value / 2;
            }

            return 0;
        }

        /// <inheritdoc cref="IValueConverter"/>
        /// <summary>
        /// Converts the value back.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="targetType">The target type.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>A new <see cref="object"/>.</returns>
        /// <seealso cref="IValueConverter"/>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}