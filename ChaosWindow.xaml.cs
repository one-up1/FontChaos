using System;
using System.Drawing.Text;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace FontChaos
{
    /// <summary>
    /// Interaction logic for ChaosWindow.xaml
    /// </summary>
    public partial class ChaosWindow : Window
    {
        private string text;

        public ChaosWindow(String text)
        {
            this.text = text;

            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            long start = Environment.TickCount;

            // Haal een array op van alle geinstalleerde lettertypes.
            System.Windows.Media.FontFamily[] fonts;
            using (InstalledFontCollection installedFonts = new InstalledFontCollection())
            {
                fonts = new System.Windows.Media.FontFamily[installedFonts.Families.Length];
                for (int i = 0; i < fonts.Length; i++)
                {
                    // Om een of andere reden zijn alle fonts uit InstalledFontCollection een
                    // System.Drawing.FontFamily en TextBlock heeft een
                    // System.Windows.Media.FontFamily nodig.
                    // Dit moet anders kunnen maar hoe? :S
                    fonts[i] = new System.Windows.Media.FontFamily(
                        installedFonts.Families[i].Name);
                    Console.WriteLine(fonts[i]);
                }
            }
            Console.WriteLine(fonts.Length + " fonts available");
            Console.WriteLine((Environment.TickCount - start) + "ms");

            Random random = new Random();
            foreach (char c in text)
            {
                Run run = new Run(Char.ToString(c));
                run.FontFamily = fonts[random.Next(0, fonts.Length)];
                run.FontSize = 18;
                textBlock.Inlines.Add(run);
            }

            Console.WriteLine((Environment.TickCount - start) + "ms");
        }
    }
}
