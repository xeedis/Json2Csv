using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Json2Csv;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void LoadFile_Click(object sender, RoutedEventArgs e)
    {
        var dialog = new SaveFileDialog();
        dialog.FileName = "Document"; 
        dialog.DefaultExt = ".json"; 
        dialog.Filter = "JSON documents (.json)|*.json"; 

        // Show save file dialog box
        bool? result = dialog.ShowDialog();

        // Process save file dialog box results
        if (result == true)
        {
            // Save document
            string filename = dialog.FileName;
        }
    }

    private void ClearButton_Click(object sender, RoutedEventArgs e)
    {
        JsonContent.Text = string.Empty;
        CsvContent.Text = string.Empty;
    }

    private void JsonContent_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if(Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.V)
        {
            if(Clipboard.ContainsText())
            {
                string clipboardText = Clipboard.GetText();
                JsonContent.Text = clipboardText;
            }
        }
    }

    private void ConvertButton_Click(object sender, RoutedEventArgs e)
    {
        if (JsonContent.Text == string.Empty) MessageBox.Show("Brak tekstu do formatowania!");
        else if (!Converter.IsValidJson(JsonContent.Text)) MessageBox.Show("Błędny format jsona!"); 
        CsvContent.Text = Converter.JsonToCsv(JsonContent.Text);
    }
}
