using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace Dot_Net7_WPF_Obfuscar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public const string ConstStringValue = "난독화 문자열 상수";
        public readonly string ReadonlyStringValue = "난독화 문자열 필드";
        public static void RegisterStartUpProgram()
        {
            Microsoft.Win32.RegistryKey? key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (key != null)
            {
                Assembly curAssembly = Assembly.GetExecutingAssembly();
                var regName = curAssembly.GetName().Name;
                ProcessModule? mainModule = Process.GetCurrentProcess().MainModule;
                if (mainModule != null && !key.GetValueNames().Contains(regName))
                {
                    key.SetValue(regName, mainModule.FileName);
                }
            }
        }
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
