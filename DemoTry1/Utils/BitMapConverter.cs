using System;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media.Imaging;

namespace DemoTry1.Utils;

public class BitmapConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is string imagePath)
        {
            try
            {
                return new Bitmap(imagePath);
            }
            catch (Exception)
            {
                // Обработка ошибок при загрузке изображения
                return null;
            }
        }
        return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}