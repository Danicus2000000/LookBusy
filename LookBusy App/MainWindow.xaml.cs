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
using System.Timers;
using System.Threading;
namespace LookBusy_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly System.Timers.Timer progressbarup = new();
        private readonly System.Timers.Timer progressbardown = new();
        private Thread? text;
        private bool threadinitalised = false;
        public MainWindow()
        {
            InitializeComponent();
            progressbarup.Interval = 5000;
            progressbarup.Elapsed += Progressbarup_Elapsed;
            progressbarup.Enabled = true;
            progressbardown.Interval = 850;
            progressbardown.Elapsed += Progressbardown_Elapsed;
        }

        private void Progressbardown_Elapsed(object? sender, ElapsedEventArgs e)//randomly decreases progress bar
        {
            this.Dispatcher.Invoke(() =>
            {
                installprogress_pb.Value -= 1;
            });
        }

        private void Progressbarup_Elapsed(object? sender, ElapsedEventArgs e)//randomly increases progress bar
        {
            this.Dispatcher.Invoke(() =>
            {
                if (installprogress_pb.Value == 99)
                {
                    installprogress_pb.Value -= 10;
                }
                else
                {
                    Random rand = new();
                    installprogress_pb.Value += rand.Next(10);
                }
                if (installprogress_pb.Value >= 50 && progressbardown.Enabled == false)
                {
                    progressbardown.Enabled = true;
                }
                if (installprogress_pb.Value < 50 && progressbardown.Enabled == true)
                {
                    progressbardown.Enabled = false;
                }
            });
        }

        private void ShowDetailsBtnClick(object sender, RoutedEventArgs e)//shows and hides text box
        {
            if ((string)showdetails_btn.Content == "Show Details")
            {
                details_txt.Visibility = Visibility.Visible;
                if (!threadinitalised)
                {
                    text = new Thread(() => DoText());
                    text.Start();
                    threadinitalised = true;
                }
                showdetails_btn.Content = "Hide Details";
            }
            else
            {
                details_txt.Visibility = Visibility.Hidden;
                showdetails_btn.Content = "Show Details";
            }
        }
        private void DoText() //generates random text for installer window
        {
            string location = System.Reflection.Assembly.GetEntryAssembly()?.Location.Replace("LookBusy\\LookBusy App\\bin\\Debug\\net6.0-windows\\LookBusy App.dll", "") ?? "";
            string[] firstlocation = ["bin", "netcore", "main", "0978EAFC6J", "tomisgayontuesdays", "connorisaplankofwood", "canoflarger", "tomisatom"];
            string[] secondlocation = ["debug", "longdancee", "legocity", "legolass", "gandalf", "danisachad", "012139123EASDJGSDIS"];
            string[] thirdlocation = ["net6.0", "img", "css", "core", "lib", "repository", "git", "prettysusbrowhywouldyouevendothat", "71821EABAF"];
            string[] forthlocation = ["vs_installer.msi", "index.html", "main.css", "console.sln", "pain.exe"];
            string[] start = ["Extracting from", "Converting", "Refactoring", "Reset base", "Deleting"];
            string[] end = ["from locale...", "index value revoked...", "repromanded...", "inversion intiated..."];
            Random rand = new();
            while (true)
            {
                this.Dispatcher.Invoke(() =>
                {
                    details_txt.AppendText(start[rand.Next(start.Length)] + " " + location + firstlocation[rand.Next(firstlocation.Length)] + "\\" + secondlocation[rand.Next(secondlocation.Length)] + "\\" + thirdlocation[rand.Next(thirdlocation.Length)] + "\\" + forthlocation[rand.Next(forthlocation.Length)] + " " + end[rand.Next(end.Length)] + "\n");
                    details_txt.ScrollToEnd();
                    if (details_txt.Text.Split("\n").Length >= 200)
                    {
                        details_txt.Text = details_txt.GetLineText(details_txt.LineCount - 10) + details_txt.GetLineText(details_txt.LineCount - 9) + details_txt.GetLineText(details_txt.LineCount - 8) + details_txt.GetLineText(details_txt.LineCount - 7) + details_txt.GetLineText(details_txt.LineCount - 6) + details_txt.GetLineText(details_txt.LineCount - 5) + details_txt.GetLineText(details_txt.LineCount - 4) + details_txt.GetLineText(details_txt.LineCount - 3) + details_txt.GetLineText(details_txt.LineCount - 2) + details_txt.GetLineText(details_txt.LineCount - 1);
                    }
                });
                Thread.Sleep(rand.Next(40, 80));
            }
        }
        private void CancelBtnClick(object sender, RoutedEventArgs e)//if cancel pressed close window
        {
            MessageBoxResult result = MessageBox.Show("Would you like to canel this install, it is " + installprogress_pb.Value + "% completed, cancelling now may cause corruption.", "Warning", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Environment.Exit(Environment.ExitCode);
            }
        }

        private void Window_Closed(object sender, EventArgs e)//if window closed kill processes
        {
            Environment.Exit(Environment.ExitCode);
        }
    }
}
