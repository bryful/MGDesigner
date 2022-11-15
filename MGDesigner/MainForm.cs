using BRY;
using Microsoft.VisualBasic.Devices;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO.Pipes;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace MGDesigner
{
	public partial class MainForm : MGForm
	{
		private string m_FileName = "";
		// ********************************************************************
		private F_Pipe m_Server = new F_Pipe();
		public void StartServer(string pipename)
		{
			m_Server.Server(pipename);
			m_Server.Reception += M_Server_Reception;
		}
		// ********************************************************************
		public void StopServer()
		{
			m_Server.StopServer();
		}
		// ********************************************************************
		private void M_Server_Reception(object sender, ReceptionArg e)
		{
			this.Invoke((Action)(() =>
			{
				PipeData pd = new PipeData(e.Text);
				Command(pd.Args, PIPECALL.PipeExec);
				ForegroundWindow();
			}));
		}
		// ********************************************************************
		public MainForm()
		{
			InitializeComponent();
			SetEventHandler(this);
			SetMGForm(this);
		}

		// ********************************************************************
		public void SetMGForm(Control ctrl)
		{
			if (ctrl.Controls.Count <= 0) return;

			foreach(Control control in ctrl.Controls)
			{
				if (control is MGNone)
				{
					if (((MGNone)control).MGForm == null)
					{
						((MGNone)control).SetMGForm(this);
					}
					SetMGForm(control);
				}
			}

		}
		// ********************************************************************
		private void Form1_Load(object sender, EventArgs e)
		{
			ToCenter();
		}
		// ********************************************************************
		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
		}
		// ********************************************************************
		private void quitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
		// ********************************************************************
		public void ToCenter()
		{
			Rectangle rct = Screen.PrimaryScreen.Bounds;
			Point p = new Point((rct.Width - this.Width) / 2, (rct.Height - this.Height) / 2);
			this.Location = p;
			ForegroundWindow();
		}
		// ********************************************************************
		public bool Export(string p)
		{
			bool ret = false;


			return ret;
		}
		// ********************************************************************
		public bool Import(string p)
		{
			return false;
		}
		// ********************************************************************
		public void ForegroundWindow()
		{
			F_W.SetForegroundWindow(this.Handle);
		}
		// ********************************************************************
		public void Command(string[] args, PIPECALL IsPipe = PIPECALL.StartupExec)
		{

		}

		private void quitToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void exportPartsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//ChkCntrol();
			ExportPartsToFile();
		}

		private void exportMixToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ExportMixToFile();
		}

		private void mgCircle2_Click(object sender, EventArgs e)
		{

		}

		private void mgKagi2_Click(object sender, EventArgs e)
		{

		}
		// *******************************************************************************



	}
}