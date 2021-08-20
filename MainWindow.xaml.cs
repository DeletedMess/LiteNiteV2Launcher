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
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Markup;
using System.Threading;
using System.Reflection;
using System.CodeDom.Compiler;

namespace LiteNite
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

		private void Info_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("L I T E N I T E\n\n Version: 2.0.0-Dev\n Product Key: Not Registered\n\n Coded with ♡ by Fexor");
		}

		private void Credits_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("L I T E N I T E\nCredits\n\n AuroraFN: Backend\n RiftV2: In-game");
		}

		private void SpecialThanks_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("L I T E N I T E\nSpecial Thanks\n\n Taki: Other Owner + Cutie\n ! Pre <3: Partner\n .exo: Partner\n Reksely: Partner\n not scizy: Trusted Moderator\n Mafia-Mac: Making the Assets\n\n And you for using this project!");
		}

		private void SessionStart_Click(object sender, RoutedEventArgs e)
		{
			// Launches Fortnite. We will have a better way soon.
			Process process = ProcessHelper.StartProcess(this.PathBR.Text + "\\FortniteGame\\Binaries\\Win64\\FortniteLauncher.exe", true, "");
			Process process2 = ProcessHelper.StartProcess(this.PathBR.Text + "\\FortniteGame\\Binaries\\Win64\\FortniteClient-Win64-Shipping_BE.exe", true, "");
			Process process4 = ProcessHelper.StartProcess(this.PathBR.Text + "\\FortniteGame\\Binaries\\Win64\\FortniteClient-Win64-Shipping_EAC.exe", true, "");
			Process process3 = ProcessHelper.StartProcess(this.PathBR.Text + "\\FortniteGame\\Binaries\\Win64\\FortniteClient-Win64-Shipping.exe", false, "-AUTH_TYPE=epic -AUTH_LOGIN=\"" + this.EmailBR.Text + "\" -AUTH_PASSWORD=\"" + this.PasswordBR.Text + "\" - SKIPPATCHCHECK");
			this.Hide();
			process3.WaitForInputIdle();
			ProcessHelper.InjectDll(process3.Id, System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "LightNiteSSL.dll"));
			Thread.Sleep(1000);
			ProcessHelper.InjectDll(process3.Id, System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Rift.dll"));
			process3.WaitForExit();
			process.Kill();
			process2.Kill();
			this.Show();
		}
	}
}
