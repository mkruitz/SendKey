using System;
using System.Windows.Forms;
using Core;

namespace GUI
{
    public partial class FormScannerStub : Form
    {
        private readonly IStore store;

        public FormScannerStub(IStore store)
        {
            this.store = store;
            InitializeComponent();
            InitializeComboBox();
        }

        private void InitializeComboBox()
        {
            comboBoxScanSets.DataSource = null;
            comboBoxScanSets.DataSource = store.AllCommands;
            comboBoxScanSets.DisplayMember = "DisplayName";
        }

        private void comboBoxScanSets_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxSendActions.DataSource = null;

            var commands = comboBoxScanSets.SelectedItem as ScanCommmands;
            if (commands == null)
                return;

            listBoxSendActions.DataSource = commands.KeysToSend;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            OpenAddOrEditForm(null);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            OpenAddOrEditForm(comboBoxScanSets.SelectedItem as ScanCommmands);
        }

        private void OpenAddOrEditForm(ScanCommmands scanCommmands)
        {
            var form = new FormEdit
            {
                Store = store,
                ScanCommands = scanCommmands
            };
            if (form.ShowDialog() == DialogResult.OK)
            {
                InitializeComboBox();
                comboBoxScanSets.SelectedItem = form.ScanCommands;
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (listBoxSendActions.SelectedItem == null)
                return;

            var keySender = new KeySender(comboBoxScanSets.SelectedItem as ScanCommmands);
            keySender.Send(listBoxSendActions.SelectedItem + "");

            listBoxSendActions.SelectedIndex = (listBoxSendActions.SelectedIndex + 1) % listBoxSendActions.Items.Count;
        }
    }
}