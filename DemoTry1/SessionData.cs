using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia.Controls.Primitives;
using DemoTry1.Models;

namespace DemoTry1;

public static class SessionData
{
    public static List<Product> Products = new List<Product>();
    
    public static bool isEditWindowOpen = false;
    
    public static ObservableCollection<Product> Cart = new ObservableCollection<Product>();
}