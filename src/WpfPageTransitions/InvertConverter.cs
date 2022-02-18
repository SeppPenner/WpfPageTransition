// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvertConverter.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The invert converter class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WpfPageTransitions;

/// <inheritdoc cref="IValueConverter"/>
/// <summary>
/// The invert converter class.
/// </summary>
/// <seealso cref="IValueConverter"/>
public class InvertConverter : IValueConverter
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
        if (value is not null)
        {
            return -(double)value;
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
