using System;
/*  
    Unnecessary

    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
*/
using System.Windows.Forms;
using EPDM.Interop.epdm;
using Microsoft.VisualBasic;

namespace CustomCardView_CSharp
{

   /*
    *  Marcos:
    *  
    *  Alternar inicialização de Custom em Program.cs - ver nota
    */ 

    public partial class Model : Form, IEdmCardViewCallback6
    {
        public Model()
        {
            InitializeComponent();
        }

        private IEdmVault5 vault1;
        private IEdmCardView63 view;
        private IEdmFile7 aFile;
        private IEdmFolder5 aFolder;

        public void Form1_Load(System.Object sender, System.EventArgs e)
        {
            try
            {
                vault1 = new EdmVault5();
                IEdmVault10 vault = (IEdmVault10)vault1;
                EdmViewInfo[] Views = null;

                vault.GetVaultViews(out Views, false);
                VaultsComboBox.Items.Clear();
                foreach (EdmViewInfo View in Views)
                {
                    VaultsComboBox.Items.Add(View.mbsVaultName);
                }
                if (VaultsComboBox.Items.Count > 0)
                {
                    VaultsComboBox.Text = (string)VaultsComboBox.Items[0];
                }
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show("HRESULT = 0x" + ex.ErrorCode.ToString("X") + " " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SelectFile_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                File1List.Items.Clear();

                if (vault1 == null)
                {
                    vault1 = new EdmVault5();
                }

                if (!vault1.IsLoggedIn)
                {
                    vault1.LoginAuto(VaultsComboBox.Text, this.Handle.ToInt32());
                }

                //Set the initial directory in the Select File dialog
                OpenFileDialog1.InitialDirectory = vault1.RootFolderPath;

                //Show the Select File dialog
                System.Windows.Forms.DialogResult DialogResult;
                DialogResult = OpenFileDialog1.ShowDialog();

                if (!(DialogResult == System.Windows.Forms.DialogResult.OK))
                {
                    // do nothing
                }
                else
                {
                    foreach (string FileName in OpenFileDialog1.FileNames)
                    {
                        File1List.Items.Add(FileName);
                        aFile = (IEdmFile7)vault1.GetFileFromPath(FileName, out aFolder);
                        ShowCard(aFolder, aFile.ID);
                    }
                }

            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show("HRESULT = 0x" + ex.ErrorCode.ToString("X") + " " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SaveCard_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                if (vault1 == null)
                {
                    vault1 = new EdmVault5();
                }

                if (!vault1.IsLoggedIn)
                {
                    vault1.LoginAuto(VaultsComboBox.Text, this.Handle.ToInt32());
                }

                view.SaveData();
                SaveCard.Enabled = false;

            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show("HRESULT = 0x" + ex.ErrorCode.ToString("X") + " " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Display the card of the selected file
        private void ShowCard(IEdmFolder5 folder, int fileID)
        {
            try
            {
                if (vault1 == null)
                {
                    vault1 = new EdmVault5();
                }

                if (!vault1.IsLoggedIn)
                {
                    vault1.LoginAuto(VaultsComboBox.Text, this.Handle.ToInt32());
                }
                IEdmVault10 vault = (IEdmVault10)vault1;

                EdmCardViewParams @params = default(EdmCardViewParams);
                @params.mlFileID = fileID;
                @params.mlFolderID = folder.ID;
                @params.mlCardID = 0;
                @params.mlX = 40;
                @params.mlY = 300;
                @params.mhParentWindow = this.Handle.ToInt32();
                @params.mlEdmCardViewFlags = (int)EdmCardViewFlag.EdmCvf_Normal;

                //Create the card view interface 
                view = vault.CreateCardViewEx2(@params, this);

                if (view == null)
                {
                    Interaction.MsgBox("The file does not have a card.");
                    return;
                }

                //Set input focus to the first control in the card
                view.SetFocus(0);

                //Enable all controls in the card
                view.Update(EdmCardViewUpdateType.EdmCvut_EnableCtrl);

                //Get the size needed to display the card 
                int width = 0;
                int height = 0;
                view.GetCardSize(out width, out height);

                //Resize the form window to make room for the card 
                this.Width = (width + 100);
                this.Height = (height + 400);
                view.ShowWindow(true);

                SaveCard.Enabled = false;

            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show("HRESULT = 0x" + ex.ErrorCode.ToString("X") + " " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EdmCardViewCallback6_SetModifiedFlag()
        {
            SaveCard.Enabled = true;
        }

        void IEdmCardViewCallback6.SetModifiedFlag()
        {
            EdmCardViewCallback6_SetModifiedFlag();
        }

        private void EdmCardViewCallback6_OnAddInInput(int lFlags)
        {
        }

        void IEdmCardViewCallback6.OnAddInInput(int lFlags)
        {
            EdmCardViewCallback6_OnAddInInput(lFlags);
        }

        private void EdmCardViewCallback6_SetCtrlData(int lCardWnd, int lCardID, int lControlID, int lVariableID, string bsVariableName, IEdmCardView5 poView, ref object poValue)
        {
            try
            {
                if (bsVariableName == "Comment")
                {
                    Interaction.MsgBox(lCardWnd + " " + lCardID + " " + lControlID + " " + lVariableID + " " + bsVariableName + " " + poValue.ToString());

                    IEdmEnumeratorVariable5 enumvar = default(IEdmEnumeratorVariable5);
                    enumvar = aFile.GetEnumeratorVariable();

                    enumvar.SetVar(bsVariableName, "", poValue, true);
                    enumvar.Flush();
                }
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show("HRESULT = 0x" + ex.ErrorCode.ToString("X") + " " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void IEdmCardViewCallback6.SetCtrlData(int lCardWnd, int lCardID, int lControlID, int lVariableID, string bsVariableName, IEdmCardView5 poView, ref object poValue)
        {
            EdmCardViewCallback6_SetCtrlData(lCardWnd, lCardID, lControlID, lVariableID, bsVariableName, poView, ref poValue);
        }

        private object EdmCardViewCallback6_GetCtrlData(int lCardWnd, int lCardID, int lControlID, int lVariableID, string bsVariableName, IEdmCardView5 poView)
        {
            Interaction.MsgBox(lCardWnd + " " + lCardID + " " + lControlID + " " + lVariableID + " " + bsVariableName + " " + poView.ToString()); //alt
            return null;
        }

        object IEdmCardViewCallback6.GetCtrlData(int lCardWnd, int lCardID, int lControlID, int lVariableID, string bsVariableName, IEdmCardView5 poView)
        {
            return EdmCardViewCallback6_GetCtrlData(lCardWnd, lCardID, lControlID, lVariableID, bsVariableName, poView);
        }

        private object EdmCardViewCallback6_GetDefaultValueComponent(EdmDefValComp eValue)
        {
            return null;
        }

        object IEdmCardViewCallback6.GetDefaultValueComponent(EdmDefValComp eValue)
        {
            return EdmCardViewCallback6_GetDefaultValueComponent(eValue);
        }

    }
}
