using System;
using System.ComponentModel;
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

        private ScanCommmands _scanCommmands;

        public ScanCommmands ScanCommands
        {
            get
            {
                return _scanCommmands;
            }
            set
            {
                _scanCommmands = value ?? new ScanCommmands();
                SetValues();
            }
        }

        public IStore Store { private get; set; }

        private void SaveValues()
        {
            _scanCommmands.DisplayName = textBoxSetName.Text;

            var splittedLines = textBoxKeysToSend.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            _scanCommmands.KeysToSend.Clear();
            _scanCommmands.KeysToSend.AddRange(splittedLines);
            _scanCommmands.ProcessName = textBoxProcessName.Text;
            _scanCommmands.TitleStartsWith = textBoxTitleStartsWith.Text;
        }

        private void SetValues()
        {
            textBoxSetName.Text = _scanCommmands.DisplayName;

            textBoxKeysToSend.Text = String.Join(Environment.NewLine, _scanCommmands.KeysToSend);
            textBoxProcessName.Text = _scanCommmands.ProcessName;
            textBoxTitleStartsWith.Text = _scanCommmands.TitleStartsWith;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            SaveValues();
            Store.Save(_scanCommmands);
            Close();
        }
    }
}
