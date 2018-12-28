using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NavigationViewItemsTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Categories = new ObservableCollection<CategoryBase>();
            Categories.Add(new Category { Name = "Category 1", Glyph = Symbol.Home, Tooltip = "This is category 1", IsEnabled = false });
            Categories.Add(new Category { Name = "Category 2", Glyph = Symbol.Keyboard, Tooltip = "This is category 2", IsEnabled = true });
            Categories.Add(new Category { Name = "Category 3", Glyph = Symbol.Library, Tooltip = "This is category 3" , IsEnabled = false });
            Categories.Add(new Category { Name = "Category 4", Glyph = Symbol.Mail, Tooltip = "This is category 4", IsEnabled = true });
        }

        public ObservableCollection<CategoryBase> Categories { get;  set; }
    }


    public class CategoryBase { }

    public class Category : CategoryBase
    {
        public string Name { get; set; }
        public string Tooltip { get; set; }
        public Symbol Glyph { get; set; }
        public bool IsEnabled { get; set; }
    }

    public class Separator : CategoryBase { }

    public class Header : CategoryBase
    {
        public string Name { get; set; }
    }

    [ContentProperty(Name = "ItemTemplate")]
    class MenuItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ItemTemplate { get; set; }
        protected override DataTemplate SelectTemplateCore(object item)
        {
            return item is Separator ? SeparatorTemplate : item is Header ? HeaderTemplate : ItemTemplate;
        }
        internal DataTemplate HeaderTemplate = (DataTemplate)XamlReader.Load(
           @"<DataTemplate xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'>
                   <NavigationViewItemHeader Content='{Binding Name}' />
                  </DataTemplate>");

        internal DataTemplate SeparatorTemplate = (DataTemplate)XamlReader.Load(
            @"<DataTemplate xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'>
                    <NavigationViewItemSeparator />
                  </DataTemplate>");
    }
}


