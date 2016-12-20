using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows;
using System.Reflection;

namespace Application
{
	public class AssemblyViewer : Form
	{
		public AssemblyViewer()
		{
			DisplayGUI ();
		}

		private Button chooseAssemblyButton;
		private TableLayoutPanel table;
		private ComboBox classCB;
		private ComboBox methodCB;
		private ComboBox paramsCB;
		private Button closeButton;
		private Assembly lastAssembly;

		public void DisplayGUI()
		{
			this.Size = new Size (500, 200);
			
			table = new TableLayoutPanel ();
			
			table.Dock = DockStyle.Fill;
			table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
			for (int i = 0; i < 5; ++i)
			{
				table.RowStyles.Add(new RowStyle(SizeType.Percent, 20));
			}

			chooseAssemblyButton = new Button();
			chooseAssemblyButton.Name = "chooseAssemblyButton";
			chooseAssemblyButton.Text = "choose";
			chooseAssemblyButton.AutoSize = true;
			chooseAssemblyButton.Dock = DockStyle.Fill;
			table.Controls.Add (chooseAssemblyButton, 0, 0);

			classCB = createComboBoxToRow ("class");
			methodCB = createComboBoxToRow ("method");
			paramsCB = createComboBoxToRow ("params");
			table.Controls.Add (classCB, 0, 1);
			table.Controls.Add (methodCB, 0, 2);
			table.Controls.Add (paramsCB, 0, 3);

			closeButton = new Button ();
			closeButton.Name = "closeButton";
			closeButton.Text = "close";
			closeButton.AutoSize = true;
			closeButton.Dock = DockStyle.Fill;
			table.Controls.Add (closeButton, 0, 4);

			this.Controls.Add (table);

			chooseAssemblyButton.Click += addClasses;
			classCB.SelectedValueChanged += addMethodes;
			methodCB.SelectedValueChanged += addParams;
			closeButton.Click += closeApp;
		}

		private ComboBox createComboBoxToRow(string name)
		{
			var res = new ComboBox ();
			res.Name = name + "ComboBox";
			res.Dock = DockStyle.Fill;
			return res;
		}

		private void addClasses(object sender, EventArgs args)
		{
			var dialogChoosing = new OpenFileDialog ();
			dialogChoosing.Filter = "dll files (*.dll)|*.dll|exe files (*.exe)|*.exe";
			if (dialogChoosing.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			try
			{
				lastAssembly = Assembly.LoadFile (dialogChoosing.FileName);
			}
			catch (System.IO.FileNotFoundException) { return; }
			catch (System.ArgumentNullException) { return; }
			classCB.Items.Clear ();
			methodCB.Items.Clear ();
			paramsCB.Items.Clear ();
			classCB.SelectedIndex = -1;
			methodCB.SelectedIndex = -1;
			paramsCB.SelectedIndex = -1;
			foreach (var singleClass in lastAssembly.GetTypes()) 
			{
				classCB.Items.Add (singleClass.FullName);
			}
		}

		private void addMethodes(object sender, EventArgs args)
		{
			var name = classCB.Items [classCB.SelectedIndex] as string;
			var selectedClass = lastAssembly.GetType (name);
			methodCB.Items.Clear ();
			paramsCB.Items.Clear ();
			methodCB.SelectedIndex = -1;
			paramsCB.SelectedIndex = -1;
			foreach (var method in selectedClass.GetMethods()) 
			{
				methodCB.Items.Add (method.Name);
			}
		}

		private void addParams(object sender, EventArgs args)
		{
			var className = classCB.Items [classCB.SelectedIndex] as string;
			var selectedClass = lastAssembly.GetType (className);
			var methodName = methodCB.Items [methodCB.SelectedIndex] as string;
			var selectedMethod = selectedClass.GetMethod (methodName);
			paramsCB.Items.Clear ();
			paramsCB.SelectedIndex = -1;
			foreach (var param in selectedMethod.GetParameters())
			{
				paramsCB.Items.Add (param);
			}
		}

		private void closeApp(object sender, EventArgs args)
		{
			this.Close ();
		}
	}
}

