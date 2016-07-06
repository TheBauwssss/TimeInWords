using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows;
using TimeToTextLib;

namespace Debug
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        LanguagePreset.Language lang = LanguagePreset.Language.English;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Timer t = new Timer();
            t.Interval = 1000;
            t.Elapsed += T_Elapsed;
            t.Start();
        }

        DateTime val = DateTime.Now;

        private void T_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(new Action(() =>
            {
                if (!(bool)checkBox.IsChecked)
                {
                    time.Content = TimeToText.GetSimple(lang, DateTime.Now);
                }
                else
                {
                    val = val.AddMinutes(5);
                    //if (val.Minute == 0)
                    //    val = val.AddHours(1);
                    time.Content = TimeToText.GetSimple(lang, val);
                }
            }));

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder b = new StringBuilder();

            for (int h = 0; h < 24; h++)
            {
                for (int m = 0; m < 60; m += 5)
                {
                    b.AppendLine(TimeToText.GetSimple(lang, new DateTime(2000, 1, 1, h, m, 0)));
                }
            }

            Clipboard.SetText(b.ToString());
        }

    }
}
