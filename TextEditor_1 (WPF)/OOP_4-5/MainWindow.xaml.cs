using Microsoft.Win32;
using System.Windows;
using System.IO;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using Xceed.Wpf.Toolkit;

namespace OOP_06
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Button openButton = new Button();
        private Button saveButton = new Button();
        private Button newFileCreateButton = new Button();

        private Button cursiveFontButton = new Button();
        private Button boldFontButton = new Button();
        private Button underlineFontButton = new Button();
        private Slider fontSizeSlider = new Slider();
        private ComboBox fontStylesComboBox = new ComboBox();
        private Button colorPickerButton = new Button();
        private ColorPicker colorPicker = new ColorPicker(); 

        public MainWindow()
        {
            InitializeComponent();            
            initButtons();
            textBox.AddHandler(DragOverEvent, new DragEventHandler(DragItem), true);
            textBox.AddHandler(DropEvent, new DragEventHandler(DropItem), true);
        }

        private void initButtons()
        {
            textBox.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;

            openButton.Style = (Style)FindResource("optionButton");
            saveButton.Style = (Style)FindResource("optionButton");
            newFileCreateButton.Style = (Style)FindResource("optionButton");

            cursiveFontButton.Style = (Style)FindResource("textOptionButton");
            boldFontButton.Style = (Style)FindResource("textOptionButton");
            underlineFontButton.Style = (Style)FindResource("textOptionButton");               

            openButton.Content = "Открыть";
            saveButton.Content = "Сохранить";
            newFileCreateButton.Content = "Новый файл";

            cursiveFontButton.Content = "K";
            boldFontButton.Content = "Ж";
            underlineFontButton.Content = "Н";

            fontStylesComboBox.ItemsSource = Fonts.SystemFontFamilies;
            fontStylesComboBox.Width = 200;
            fontStylesComboBox.Height = 25;
            fontStylesComboBox.Margin = new Thickness(20, 0, 0, 0);

            fontSizeSlider.Margin = new Thickness(20, 0, 0, 0);
            fontSizeSlider.Minimum = 1;
            fontSizeSlider.Maximum = 128;
            fontSizeSlider.MinWidth = 200;
            fontSizeSlider.MaxWidth = 200;
            fontSizeSlider.Height = 25;
            fontSizeSlider.TickFrequency = 10;

            colorPickerButton.Width = 40;
            colorPickerButton.Height = 40;

            colorPickerButton.Margin = new Thickness(20, 0, 0, 0);

            colorPicker.Width = 100;
            colorPicker.Height = 20;
            colorPicker.SelectedColor = Colors.Black;
            colorPicker.Margin = new Thickness(20, 0, 0, 0);

            openButton.Click += new RoutedEventHandler(openButton_Click);
            saveButton.Click += new RoutedEventHandler(saveButton_Click);
            newFileCreateButton.Click += new RoutedEventHandler(newFileCreateButton_Click);

            fontSizeSlider.ValueChanged += new RoutedPropertyChangedEventHandler<double>(fontSizeChanged);
            cursiveFontButton.Click += new RoutedEventHandler(cursiveFontButton_Click);
            boldFontButton.Click += new RoutedEventHandler(boldFontButton_Click);
            underlineFontButton.Click += new RoutedEventHandler(underlineFontButton_Click);
            fontStylesComboBox.SelectionChanged += new SelectionChangedEventHandler(selectFontStyle_Select);

            colorPicker.SelectedColorChanged += new RoutedPropertyChangedEventHandler<Color?>(colorPicker_Select);

        }

        private void fileOptionsButton_Click(object sender, RoutedEventArgs e)
        {
            stackPanel.Children.Clear();            
            stackPanel.Children.Add(openButton);
            stackPanel.Children.Add(saveButton);
            stackPanel.Children.Add(newFileCreateButton); 
        }

        private void textOptionsButton_Click(object sender, RoutedEventArgs e)
        {
            stackPanel.Children.Clear();
            stackPanel.Children.Add(cursiveFontButton);
            stackPanel.Children.Add(boldFontButton);
            stackPanel.Children.Add(underlineFontButton);
            stackPanel.Children.Add(fontSizeSlider);
            stackPanel.Children.Add(fontStylesComboBox);

            stackPanel.Children.Add(colorPicker);
            
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void openButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Txt files (*.txt)|*.txt|Rtf files (*.rtf)|*.rtf";
            if (open.ShowDialog() == true)
            {
                string fileName = open.FileName;
                if (File.Exists(fileName))
                {
                    TextRange textRange = new TextRange(textBox.Document.ContentStart, textBox.Document.ContentEnd);
                    FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate);
                    textRange.Load(fileStream, DataFormats.Rtf);

                    fileStream.Close();
                    statusText.Text = "Открытие выполнено";
                }
            }
            else
                return;
                       
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();            
            saveFileDialog.Filter = "Txt files (*.txt)|*.txt|Rtf files (*.rtf)|*.rtf";
            saveFileDialog.FilterIndex = 1;
            if (saveFileDialog.ShowDialog() == true)
            {
                TextRange documentTextRange = new TextRange(textBox.Document.ContentStart, textBox.Document.ContentEnd);
                using (FileStream fs = File.Create(saveFileDialog.FileName))
                {
                    documentTextRange.Save(fs, DataFormats.Rtf);
                    statusText.Text = "Сохранение выполнено";
                }                
            }
            else
                return;
        }

        private void newFileCreateButton_Click(object sender, RoutedEventArgs e)
        {
            TextRange documentTextRange = new TextRange(textBox.Document.ContentStart, textBox.Document.ContentEnd);
            documentTextRange.Text = "";
        }

        private void fontSizeChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            TextSelection selectedText = textBox.Selection;

            if (selectedText.Text != "")
                selectedText.ApplyPropertyValue(TextElement.FontSizeProperty, fontSizeSlider.Value);                  
            else      
                selectedText.ApplyPropertyValue(TextElement.FontSizeProperty, fontSizeSlider.Value);

            textBox.Focus();
        }

        private void cursiveFontButton_Click(object sender, RoutedEventArgs e)
        {
            TextSelection selectedText = textBox.Selection;

            if(selectedText.GetPropertyValue(TextElement.FontStyleProperty) == (object)FontStyles.Italic)
                selectedText.ApplyPropertyValue(TextElement.FontStyleProperty, FontStyles.Normal);
            else
                selectedText.ApplyPropertyValue(TextElement.FontStyleProperty, FontStyles.Italic);

            textBox.Focus();
        }

        private void boldFontButton_Click(object sender, RoutedEventArgs e)
        {
            TextSelection selectedText = textBox.Selection;

            if (selectedText.GetPropertyValue(TextElement.FontWeightProperty) == (object)FontWeights.Bold)
                selectedText.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Normal);
            else
                selectedText.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);
            textBox.Focus();
        }

        private void underlineFontButton_Click(object sender, RoutedEventArgs e)
        {
            TextSelection selectedText = textBox.Selection;

            if(selectedText.GetPropertyValue(TextElement.FontStyleProperty) == (object)FontStyles.Oblique)
                selectedText.ApplyPropertyValue(TextElement.FontStyleProperty, FontStyles.Normal);                
            else
                selectedText.ApplyPropertyValue(TextElement.FontStyleProperty, FontStyles.Oblique);

            textBox.Focus();

        }

        private void selectFontStyle_Select(object sender, RoutedEventArgs e)
        {
            TextSelection selectedText = textBox.Selection;     
            selectedText.ApplyPropertyValue(FontFamilyProperty, Fonts.SystemFontFamilies.ElementAt(fontStylesComboBox.SelectedIndex));
            textBox.Focus();
        }

        private void colorPicker_Select(object sender, RoutedEventArgs e)
        {
            TextSelection selectedText = textBox.Selection;
            SolidColorBrush color = new SolidColorBrush(colorPicker.SelectedColor.Value);
            selectedText.ApplyPropertyValue(TextElement.ForegroundProperty, color);
            textBox.Focus();
        } 
        
        private void langSwitcher_Checked(object sender, RoutedEventArgs e)
        {
            if(langSwitcher.IsChecked == true)
            {
                fileOptionsButton.Content = "File";
                textOptionsButton.Content = "Text";

                openButton.Content = "Open";
                saveButton.Content = "Save";
                newFileCreateButton.Content = "New file";

                cursiveFontButton.Content = "C";
                boldFontButton.Content = "B";
                underlineFontButton.Content = "O";
            }
        }

        private void langSwitcher_Unchecked(object sender, RoutedEventArgs e)
        {
            fileOptionsButton.Content = "Файл";
            textOptionsButton.Content = "Текст";

            openButton.Content = "Открыть";
            saveButton.Content = "Сохранить";
            newFileCreateButton.Content = "Новый файл";

            cursiveFontButton.Content = "K";
            boldFontButton.Content = "Ж";
            underlineFontButton.Content = "_";
        }

        private void DragItem(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effects = DragDropEffects.All;            
            else
                e.Effects = DragDropEffects.None;

            e.Handled = false;
        }

        private void DropItem(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (File.Exists(files[0]))
                {
                    try
                    {
                        TextRange range = new TextRange(textBox.Document.ContentStart, textBox.Document.ContentEnd);
                        FileStream fs = new FileStream(files[0], FileMode.OpenOrCreate);
                        range.Load(fs, DataFormats.Rtf);
                        label.Content = files[0];
                        fs.Close();
                    }
                    catch
                    {
                        Xceed.Wpf.Toolkit.MessageBox.Show("Неподдерживаемый тип");
                    }
                }
            }
        }
        static int i = 0;
        private void textBox_Changed(object sender, TextChangedEventArgs e)
        {
            
            TextRange textRange = new TextRange(textBox.Document.ContentStart, textBox.Document.ContentEnd);
            char[] separators = { ' ','.','?', };
            i++;
            if (i == 1 || i == 2)
                return;                       
            countWords.Content = "Всего слов: " +  WordCount.countWords(textRange.Text); 
        }
    }
}
