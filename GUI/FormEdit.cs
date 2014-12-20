using System;
using System.Windows.Forms;
using Core;

namespace GUI
{
    public partial class FormEdit : Form
    {
        public FormEdit()
        {
            InitializeComponent();
        }

        private ScanCommmands scanCommmands;

        public ScanCommmands ScanCommands
        {
            get
            {
                return scanCommmands;
            }
            set
            {
                scanCommmands = value ?? new ScanCommmands();
                SetValues();
            }
        }

        public IStore Store { private get; set; }

        private void SaveValues()
        {
            scanCommmands.DisplayName = textBoxSetName.Text;

            var splittedLines = textBoxKeysToSend.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            scanCommmands.KeysToSend.Clear();
            scanCommmands.KeysToSend.AddRange(splittedLines);
            scanCommmands.ProcessName = textBoxProcessName.Text;
            scanCommmands.TitleStartsWith = textBoxTitleStartsWith.Text;
        }

        private void SetValues()
        {
            textBoxSetName.Text = scanCommmands.DisplayName;

            textBoxKeysToSend.Text = String.Join(Environment.NewLine, scanCommmands.KeysToSend);
            textBoxProcessName.Text = scanCommmands.ProcessName;
            textBoxTitleStartsWith.Text = scanCommmands.TitleStartsWith;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            SaveValues();
            Store.Save(scanCommmands);
            Close();
        }
    }
}
