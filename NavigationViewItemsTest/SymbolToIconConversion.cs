using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;

// The Templated Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234235

namespace NavigationViewItemsTest
{
    public sealed class SymbolToIconConversion : Control
    {
        internal static Dictionary<Symbol, string> enumValuesCollection = new Dictionary<Symbol, string>();

        public SymbolToIconConversion()
        {
            this.DefaultStyleKey = typeof(SymbolToIconConversion);
            PopulateEnumCollection();
        }

        public static Dictionary<Symbol, string> EnumValuesCollection
        {
            get { return enumValuesCollection; }
            set { enumValuesCollection = value; }
        }

        internal void PopulateEnumCollection()
        {
            if (enumValuesCollection.Count == 0)
            {
                enumValuesCollection.Add(Symbol.Accept, "M0,4 5,9 9,0 4,5");
                enumValuesCollection.Add(Symbol.ClosedCaption, "F1 M 22,12L 26,12L 26,22L 36,22L 36,26L 26,26L 26,36L 22,36L 22,26L 12,26L 12,22L 22,22L 22,12 Z");
                enumValuesCollection.Add(Symbol.Save, "M0,4 5,9 9,0 4,5");
                enumValuesCollection.Add(Symbol.Add, "M0,5 H10 M5,5 V10Z");
            }

        }


        public Symbol MySymbol
        {
            get { return (Symbol)GetValue(MySymbolProperty); }
            set { SetValue(MySymbolProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MySymbol.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MySymbolProperty =
            DependencyProperty.Register("MySymbol", typeof(Symbol), typeof(SymbolToIconConversion), new PropertyMetadata(default(Symbol), new
                 PropertyChangedCallback(OnSymbolChanged)));



        internal Geometry Geometry
        {
            get { return (Geometry)GetValue(GeometryProperty); }
            set { SetValue(GeometryProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Geometry.  This enables animation, styling, binding, etc...
        internal static readonly DependencyProperty GeometryProperty =
            DependencyProperty.Register("Geometry", typeof(Geometry), typeof(SymbolToIconConversion), new PropertyMetadata(null));

        private static void OnSymbolChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SymbolToIconConversion symbolIcon = d as SymbolToIconConversion;
            if (symbolIcon != null)
            {
                foreach (var value in EnumValuesCollection)
                {
                    if (symbolIcon.MySymbol == value.Key)
                    {
                        //symbolIcon.Geometry = (Geometry)XamlBindingHelper.ConvertValue(typeof(Geometry), value.Value);
                        //return;

                        symbolIcon.SetValue(GeometryProperty, (Geometry)XamlBindingHelper.ConvertValue(typeof(Geometry), value.Value));
                        return;
                    }
                }
            }
        }
    }
}
